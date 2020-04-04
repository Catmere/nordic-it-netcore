using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain.EventArgs.Model
{
	public class StatusChangedReminderModel
	{
		public string ContactID { get; set; }
		public DateTimeOffset AlarmDate { get; set; }
		public string AlarmMessage { get; set; }
		public ReminderItemStatus Status { get; set; }
		public ReminderItemStatus PreviousStatus { get; set; }
		public StatusChangedReminderModel()
		{

		}
		public StatusChangedReminderModel(ReminderItem reminder, ReminderItemStatus prevStatus)
		{
			ContactID = reminder.ContactID;
			AlarmDate = reminder.AlarmDate;
			AlarmMessage = reminder.AlarmMessage;
			Status = reminder.Status;
			PreviousStatus = prevStatus;
		}
	}
}
