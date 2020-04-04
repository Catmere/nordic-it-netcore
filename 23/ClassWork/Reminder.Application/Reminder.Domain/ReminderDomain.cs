using Reminder.Domain.EventArgs;
using Reminder.Domain.EventArgs.Model;
using Reminder.Parsing;
using Reminder.Receiver.Core;
using Reminder.Sender.Core;
using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Reminder.Domain
{
    public class ReminderDomain
    {
        private IReminderStorage _storage;
        private IReminderReceiver _receiver;
        private IReminderSender _sender;
        private Timer _awaitingRemindersCheckTimer;
        private Timer _readyToSendRemindersSendTimer;
        public event EventHandler<ReminderEventStatusChangedEventArgs> ReminderItemStatusChanged;
        public event EventHandler<ReminderEventSendingFailedEventArgs> ReminderItemSendingFailed;

        public event EventHandler<MessageEventParsedEventArgs> MessageParsed;
        public event EventHandler<MessageEventParsingFailedEventArgs> MessageParsingFailed;
        public event EventHandler<MessageEventParsedEventArgs> ReminderIsOutdated;



        public ReminderDomain(IReminderStorage storage, IReminderReceiver receiver, IReminderSender sender)
        {
            _storage = storage;
            _receiver = receiver;
            _sender = sender;
            _receiver.MessageRecieved += RecieverOnMessageRecieved;
        }



        public void Run()
        {
            _awaitingRemindersCheckTimer = new Timer(
                CheckAwaitingReminders,
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(1));
            _readyToSendRemindersSendTimer = new Timer(
                SendReadyToSendReminders,
                null,
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(1));

            _receiver.Run();
        }

        private void CheckAwaitingReminders(object _)
        {
            //read items in status Awaiting
            List<ReminderItem> list = _storage.Get(ReminderItemStatus.Awaiting);
            foreach (ReminderItem x in list)
            {
                //check IsTimeToSend, if true
                if (x.IsTimeToSend)
                {
                    //update status to ReadyToSend
                    ReminderItemStatus buff = x.Status;
                    x.Status = ReminderItemStatus.ReadyToSend;
                    _storage.Update(x);
                    if (ReminderItemStatusChanged != null)
                        ReminderItemStatusChanged(this, new ReminderEventStatusChangedEventArgs(new StatusChangedReminderModel(x, buff)));
                }
            }
        }

        private void SendReadyToSendReminders(object _)
        {
            List<ReminderItem> list = _storage.Get(ReminderItemStatus.ReadyToSend);
            foreach (ReminderItem item in list)
            {
                ReminderItemStatus previousStatus = item.Status;
                try
                {
                    _sender.Send(item.ContactID, item.AlarmMessage);
                    //send, if not - exception
                    item.Status = ReminderItemStatus.SuccessfullySent;
                    _storage.Update(item);
                    if (ReminderItemStatusChanged != null)
                        ReminderItemStatusChanged(this, new ReminderEventStatusChangedEventArgs(new StatusChangedReminderModel(item, previousStatus)));
                }
                catch (Exception e)
                {
                    //if not sent					
                    item.Status = ReminderItemStatus.Failed;
                    _storage.Update(item);
                    if (ReminderItemSendingFailed != null)
                        ReminderItemSendingFailed(this, new ReminderEventSendingFailedEventArgs(new SendingFailedReminderModel(item, previousStatus, e)));
                }
            }
        }
        private void RecieverOnMessageRecieved(object sender, MessageReceivedEventArgs e)
        {
            //parsing of the e.Message to get alarm message and date
            var parsedMessage = MessageParser.ParseMessage(e.Message);
            
            if (parsedMessage == null)
            {
                //raise event MessageParsingFailed for the TG sender
                MessageParsingFailed?.Invoke(this, new MessageEventParsingFailedEventArgs(e.Message, e.ContactId));
                try
                {
                    _sender.Send(e.ContactId, "Wrong format, try again!");                    
                }
                catch
                {
                    // not sent
                }
                return;
            }
            
            var item = new ReminderItem(
                parsedMessage.Message, 
                parsedMessage.alarmDate, 
                Guid.NewGuid(), 
                e.ContactId);
            if (MessageParsed != null)
                MessageParsed(this, new MessageEventParsedEventArgs(new ParsedMessageModel(parsedMessage.alarmDate, parsedMessage.Message, e.ContactId)));
            //adding new ReminderItem to the storage
            if (item.IsOutdated)
            {
                ReminderIsOutdated?.Invoke(this, new MessageEventParsedEventArgs(new ParsedMessageModel(parsedMessage.alarmDate, parsedMessage.Message, e.ContactId)));
                _sender.Send(e.ContactId, "Reminder is outdated!");
                return;
            }
                
            _storage.Add(item);
            //raise event ReminderItemAdded to send the message for OK
            _sender.Send(e.ContactId, $"Reminder \"{item.AlarmMessage}\"" +
                $" will be sent on {item.AlarmDate} " +
                $"(in {item.TimeToAlarm.ToString(@"d\.hh\:mm\:ss")})!"); //TODO: расширить функционал
        }
    }
}
