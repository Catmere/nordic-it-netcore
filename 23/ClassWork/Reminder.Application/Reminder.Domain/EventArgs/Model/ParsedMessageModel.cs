using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain.EventArgs.Model
{
    public class ParsedMessageModel
    {
        public DateTimeOffset AlarmDateTime { get; set; }
        public string Message { get; set; }
        public string ContactId { get; set; }
        public ParsedMessageModel(DateTimeOffset alarmDateTime, string message, string contactId)
        {
            AlarmDateTime = alarmDateTime;
            Message = message;
            ContactId = contactId;
        }
    }
}
