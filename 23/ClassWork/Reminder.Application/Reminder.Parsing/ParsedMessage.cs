using System;

namespace Reminder.Parsing
{
    public class ParsedMessage
    {
        public string Message { get; set; }
        public DateTimeOffset alarmDate { get; set; }

    }
}