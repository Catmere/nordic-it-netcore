using System;
using System.Collections.Generic;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			IReminderStorage storage = new InMemoryReminderStorage();

			/*			((InMemoryReminderStorage)storage).RunWhenEventDone
			*/

			storage.Add(new ReminderItem("Hello World!",
				DateTimeOffset.Now,
				Guid.NewGuid(),
				"TelegramContactId"
				));
			List<ReminderItem> list = storage.Get(ReminderItemStatus.Awaiting);
			foreach (ReminderItem x in list)
			{
				Console.WriteLine(x.ToString());
			}
		}
	}
}
