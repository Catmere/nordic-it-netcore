using Reminder.Domain.EventArgs.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain.EventArgs
{
	public class ReminderEventStatusChangedEventArgs: System.EventArgs
	{
		public StatusChangedReminderModel Reminder { get; set; }
		public ReminderEventStatusChangedEventArgs(StatusChangedReminderModel reminder)
		{
			Reminder = reminder;
		}
	}
}
