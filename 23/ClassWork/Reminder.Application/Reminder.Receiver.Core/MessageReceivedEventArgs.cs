using System;

namespace Reminder.Receiver.Core
{
    public class MessageReceivedEventArgs :EventArgs
    {
        public string Message { get; set; }

        public string ContactId { get; set; }

        public MessageReceivedEventArgs(string message, string contactId)
        {
            Message = message;
            ContactId = contactId;
        }
    }
}