using Reminder.Receiver.Core;
using System;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace Reminder.Receiver.Telegram
{
    public class TelegramReminderReceiver : IReminderReceiver
    {
        private TelegramBotClient _botClient;
        public event EventHandler<MessageReceivedEventArgs> MessageRecieved;

        public TelegramReminderReceiver(string token, IWebProxy proxy = null)
        {

            _botClient = proxy == null
                ? new TelegramBotClient(token)
                : new TelegramBotClient(token, proxy);
        }
        public void Run()
        {
            _botClient.OnMessage += BotClientOnMessage;
            _botClient.StartReceiving();
        }

        private void BotClientOnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Type == global::Telegram.Bot.Types.Enums.MessageType.Text)
            {
                OnMessageReceived(this, new MessageReceivedEventArgs(e.Message.Text, e.Message.Chat.Id.ToString()));
            }
        }
        protected virtual void OnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            MessageRecieved?.Invoke(sender, e);
        }
    }
}
