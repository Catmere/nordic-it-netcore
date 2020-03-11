using System;

namespace Reminder.Parsing
{
    public static class MessageParser
    {
        public static ParsedMessage ParseMessage(string text)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            var firstSpacePosition = text.IndexOf(" ");
            if (firstSpacePosition < 0)
                return null;

            string potentialDate = text.Substring(0, firstSpacePosition);
            if (!DateTimeOffset.TryParse(potentialDate, out var date))
                return null;

            string message = text.Substring(firstSpacePosition).Trim();
            if (string.IsNullOrEmpty(message))
                return null;

            return new ParsedMessage
            {
                alarmDate = date,
                Message = message
            };

        }
    }
}
