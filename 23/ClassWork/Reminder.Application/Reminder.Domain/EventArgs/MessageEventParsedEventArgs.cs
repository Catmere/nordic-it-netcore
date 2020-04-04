using Reminder.Domain.EventArgs.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain.EventArgs
{
    public class MessageEventParsedEventArgs :System.EventArgs
    {
        public ParsedMessageModel ParsedMessage { get; set; }
        public MessageEventParsedEventArgs(ParsedMessageModel parsedMessage)
        {
            ParsedMessage = parsedMessage;
        }
    }
}
