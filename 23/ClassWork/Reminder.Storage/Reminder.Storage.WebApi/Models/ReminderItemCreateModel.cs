using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.Storage.WebApi.Models
{
    public class ReminderItemCreateModel
    {
        public string ContactID { get; set; }
        public DateTimeOffset AlarmDate { get; set; }
        public string AlarmMessage { get; set; }
        public ReminderItemCreateModel(ReminderItem reminderItem)
        {
            ContactID = reminderItem.ContactID;
            AlarmDate = reminderItem.AlarmDate;
            AlarmMessage = reminderItem.AlarmMessage;
        }
        public ReminderItem ToReminderItem()
        {
            return new ReminderItem(AlarmMessage, AlarmDate, Guid.NewGuid(), ContactID);
        }
    }
}
