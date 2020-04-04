using Reminder.Domain.EventArgs.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain
{
	public class ReminderEventSendingFailedEventArgs : System.EventArgs
	{
		public SendingFailedReminderModel Reminder { get; set; }

		public ReminderEventSendingFailedEventArgs(SendingFailedReminderModel reminder)
		{
			Reminder = reminder;
		}
	}
}
