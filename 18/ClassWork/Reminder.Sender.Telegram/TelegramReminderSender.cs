using Reminder.Receiver.Core;
using Reminder.Sender.Core;
using System;
using System.Net;
using Telegram.Bot;

namespace Reminder.Sender.Telegram
{
    public class TelegramReminderSender : IReminderSender
    {
        private TelegramBotClient _botClient;
        public event EventHandler<MessageReceivedEventArgs> MessageRecieved;

        public TelegramReminderSender(string token, IWebProxy proxy = null)
        {
            _botClient = proxy == null
                        ? new TelegramBotClient(token)
                        : new TelegramBotClient(token, proxy);
        }
        public void Send(string contactId, string message)
        {
            var chatId = new global::Telegram.Bot.Types.ChatId(long.Parse(contactId));

            _botClient.SendTextMessageAsync(chatId, message);
        }
    }
}

