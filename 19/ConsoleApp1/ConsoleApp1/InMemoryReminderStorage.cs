using Reminder.Storage.Core;
using System;
using System.Collections.Generic;

namespace Reminder.Storage.InMemory
{

	public class InMemoryReminderStorage : IReminderStorage

	{
		public delegate void WhenAddingDone(object sender, EventArgs e);
		public event EventHandler OnAddSuccess;
		public WhenAddingDone RunWhenEventDone { get; set; }


		private readonly Dictionary<Guid, ReminderItem> _storage;
		public InMemoryReminderStorage()
		{
			_storage = new Dictionary<Guid, ReminderItem>();
		}
		public void Add(ReminderItem reminderItem)
		{
			_storage.Add(reminderItem.Id, reminderItem);
			//RunWhenEventDone(this, EventArgs.Empty);
		}

		public ReminderItem Get(Guid id)
		{
			return _storage.ContainsKey(id)
				? _storage[id]
				: null;
		}

		public List<ReminderItem> Get(ReminderItemStatus status)
		{
			var listOfReminderItems = new List<ReminderItem>();
			foreach (var reminderItem in _storage.Values)
			{
				if (reminderItem.Status == status)
				{
					listOfReminderItems.Add(reminderItem);
				}
			}
			return listOfReminderItems;
		}

		public void Update(ReminderItem reminderItem)
		{
			_storage[reminderItem.Id] = reminderItem;
		}
	}
}
