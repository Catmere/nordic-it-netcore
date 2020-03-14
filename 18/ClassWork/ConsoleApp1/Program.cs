using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using MihaZupan;
using Reminder.Domain;
using Reminder.Domain.EventArgs;
using Reminder.Receiver.Core;
using Reminder.Receiver.Telegram;
using Reminder.Sender.Core;
using Reminder.Sender.Telegram;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            const string botToken = "1140904212:AAFW4RAEJWxNxgZmJ5IjGtsJxvAfSazAPtI";
            const string proxyHost = "96.96.33.133";
            const int proxyPort = 1080;

            IWebProxy proxy = new HttpToSocks5Proxy(proxyHost, proxyPort);

            IReminderStorage storage = new InMemoryReminderStorage();
            IReminderReceiver reciever = new TelegramReminderReceiver(botToken, proxy);
            IReminderSender sender = new TelegramReminderSender(botToken, proxy);
            ReminderDomain domain = new ReminderDomain(storage, reciever, sender);

            /*((InMemoryReminderStorage)storage).RunWhenAddingDone = (sender, e) =>
			{
				Console.WriteLine("Delegate New item added!");
			};
*/
            /*((InMemoryReminderStorage)storage).OnAddSuccess += (sender, e) =>
			{
				Console.WriteLine("EVENT New item added!");
			};
			
			((InMemoryReminderStorage)storage).OnUpdateSuccess += (sender, e) =>
			{
				Console.WriteLine("EVENT Item updated!");
			};*/

            domain.ReminderItemStatusChanged += OnReminderItemStatusChange;
            domain.ReminderItemSendingFailed += OnReminderItemSendingFailure;
            reciever.MessageRecieved += OnMessageRecieved;
            domain.MessageParsed += OnMessageParsed;
            domain.MessageParsingFailed += OnMessageParsingFailure;
            domain.ReminderIsOutdated += OnRecievingOutdatedReminder;


            /*Guid itemGuid = Guid.NewGuid();
            storage.Add(new ReminderItem("А вот так можно использовать твой ID в телеге",
                DateTimeOffset.Now + TimeSpan.FromSeconds(1),
                itemGuid,
                "66229908"
                ));*/


            domain.Run();
            Console.WriteLine("Press any key to close app...");
            Console.ReadKey();

            /* List<ReminderItem> list = storage.Get(ReminderItemStatus.Awaiting);
			 foreach(ReminderItem x in list)
			 {
				 Console.WriteLine(x.ToString());
			 }*/

            /*storage.Update(new ReminderItem("Hello World!",
				DateTimeOffset.Now,
				itemGuid,
				"TelegramContact ID"
				));
			list = storage.Get(ReminderItemStatus.Awaiting);
			foreach (ReminderItem x in list)
			{
				Console.WriteLine(x.ToString());
			}*/
        }
        private static void OnReminderItemStatusChange(object sender, ReminderEventStatusChangedEventArgs e)
        {
            Console.WriteLine($"Reminder for ID {e.Reminder.ContactID} now changed status from {e.Reminder.PreviousStatus} to {e.Reminder.Status}!");
        }
        private static void OnReminderItemSendingFailure(object sender, ReminderEventSendingFailedEventArgs e)
        {
            Console.WriteLine($"Reminder for ID {e.Reminder.ContactID} failed to send with exception {e.Reminder.SeenException.Message}!");
        }
        private static void OnMessageRecieved(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine($"Recieved message from {e.ContactId} with message {e.Message}, parsing...");
        }
        private static void OnMessageParsed(object sender, MessageEventParsedEventArgs e)
        {
            var timerForParsed = new Timer(
                            (x) => Console.WriteLine($"Successfully parsed message from {e.ParsedMessage.ContactId}:" +
                            $" result date - {e.ParsedMessage.AlarmDateTime:u}," +
                            $" message - \"{e.ParsedMessage.Message}\"!"),
                            null,
                            TimeSpan.FromMilliseconds(50),
                            TimeSpan.Zero);
        }
        private static void OnMessageParsingFailure(object sender, MessageEventParsingFailedEventArgs e)
        {
            var timerForParsingFailure = new Timer(
                            (x) => Console.WriteLine($"Parsing failed at message from {e.ContactId} with text \"{e.Message}\""),
                            null,
                            TimeSpan.FromMilliseconds(50),
                            TimeSpan.Zero);
        }
        private static void OnRecievingOutdatedReminder(object sender, MessageEventParsedEventArgs e)
        {
            var timerForOutdated = new Timer(
                            (x) => Console.WriteLine($"Reminder from {e.ParsedMessage.ContactId} \"{e.ParsedMessage.Message}\" is outdated!"),
                            null,
                            TimeSpan.FromMilliseconds(50),
                            TimeSpan.Zero);
        }
    }
}
