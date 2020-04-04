using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain.EventArgs
{
    public class MessageEventParsingFailedEventArgs :System.EventArgs
    {
        public string Message { get; set; }

        public string ContactId { get; set; }

        public MessageEventParsingFailedEventArgs(string message, string contactId)
        {
            Message = message;
            ContactId = contactId;
        }
    }
}
