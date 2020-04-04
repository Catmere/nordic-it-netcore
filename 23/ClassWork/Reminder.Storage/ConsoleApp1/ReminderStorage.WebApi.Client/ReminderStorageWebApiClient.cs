using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ReminderStorage.WebApi.Client
{
    public class ReminderStorageWebApiClient : IReminderStorage
    {
        public void Add(ReminderItem reminderItem)
        {
            // TODO
        }

        public ReminderItem Get(Guid id)
        {
            //TODO
        }

        public List<ReminderItem> Get(ReminderItemStatus status)
        {
            // TODO
        }

        public List<ReminderItem> Get(int count = 0, int startPosition = 0)
        {
            // TODO
        }

        public void Update(ReminderItem reminderItem)
        {
            // TODO
        }
    }
}
