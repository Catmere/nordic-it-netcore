using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.Storage.WebApi.Models
{
    public class ReminderItemGetModel
    {
        public Guid Id { get; set; }
        public string ContactID { get; set; }
        public ReminderItemStatus Status { get; set; }
        public DateTimeOffset AlarmDate { get; set; }
        public string AlarmMessage { get; set; }
        public ReminderItemGetModel()
        {                
        }
        public ReminderItemGetModel(ReminderItem reminderItem)
        {
            Id = reminderItem.Id;
            ContactID = reminderItem.ContactID;
            Status = reminderItem.Status;
            AlarmDate = reminderItem.AlarmDate;
            AlarmMessage = reminderItem.AlarmMessage;
        }
        
    }
}
