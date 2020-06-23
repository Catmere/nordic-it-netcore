using System;

namespace Reminder.Parsing
{
    public static class MessageParser
    {
        public static ParsedMessage ParseMessage(string text)
        {
            DateTimeOffset date;
            if (string.IsNullOrEmpty(text))
                return null;

            var firstSpacePosition = FirstSpacePosition(text);
            if (firstSpacePosition < 0)
                return null;

            string potentialCommand = text.Substring(0, firstSpacePosition);
            if (potentialCommand == "Через" || potentialCommand == "через")
            {
                text = text.Substring(FirstSpacePosition(text)).Trim();
                var potentialTime = text.Substring(0, FirstSpacePosition(text)).Trim();
                if (!int.TryParse(text.Substring(0, FirstSpacePosition(text)).Trim(), out int time))
                    return null;
                date = DateTimeOffset.Now + TimeSpan.FromMinutes(time);
            }
            else
            {
                string potentialDate = text.Substring(0, firstSpacePosition);
                if (!DateTimeOffset.TryParse(potentialDate, out date))
                    return null;
            }
            string message = text.Substring(FirstSpacePosition(text)).Trim();
                if (string.IsNullOrEmpty(message))
                    return null;
            
            return new ParsedMessage
            {
                alarmDate = date,
                Message = message
            };

        }
        public static Int32 FirstSpacePosition(string text)
        {
            return text.IndexOf(" ");
        }
    }
}
