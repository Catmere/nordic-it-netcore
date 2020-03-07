using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain.EventArgs.Model
{
	public class SendingFailedReminderModel
	{
		public string ContactID { get; set; }
		public DateTimeOffset AlarmDate { get; set; }
		public string AlarmMessage { get; set; }
		public ReminderItemStatus Status { get; set; }
		public ReminderItemStatus PreviousStatus { get; set; }
		public Exception SeenException { get; set; }
		public SendingFailedReminderModel()
		{

		}
		public SendingFailedReminderModel(ReminderItem reminder, ReminderItemStatus prevStatus, Exception seenException)
		{
			ContactID = reminder.ContactID;
			AlarmDate = reminder.AlarmDate;
			AlarmMessage = reminder.AlarmMessage;
			Status = reminder.Status;
			PreviousStatus = prevStatus;
			SeenException = seenException;
		}
	}
}
