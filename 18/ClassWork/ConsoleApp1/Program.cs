using System;
using System.Collections.Generic;
using System.Threading;
using Reminder.Domain;
using Reminder.Domain.EventArgs;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;

namespace ConsoleApp1
{
    class Program
    {
       
        static void Main(string[] args)
        {
            IReminderStorage storage = new InMemoryReminderStorage();
            ReminderDomain domain = new ReminderDomain(storage);

            /*((InMemoryReminderStorage)storage).RunWhenAddingDone = (sender, e) =>
			{
				Console.WriteLine("Delegate New item added!");
			};
*/
            /*((InMemoryReminderStorage)storage).OnAddSuccess += (sender, e) =>
			{
				Console.WriteLine("EVENT New item added!");
			};
			
			((InMemoryReminderStorage)storage).OnUpdateSuccess += (sender, e) =>
			{
				Console.WriteLine("EVENT Item updated!");
			};*/

            domain.ReminderItemStatusChanged += OnReminderItemStatusChange;
            domain.ReminderItemSendingFailed += OnReminderItemSendingFailure;


            Guid itemGuid = Guid.NewGuid();
            storage.Add(new ReminderItem("Hello World!",
                DateTimeOffset.Now + TimeSpan.FromSeconds(1),
                itemGuid,
                "TelegramContactId"
                ));
            

            domain.Run();
            Console.WriteLine("Press any key to close app...");
            Console.ReadKey();

            /* List<ReminderItem> list = storage.Get(ReminderItemStatus.Awaiting);
			 foreach(ReminderItem x in list)
			 {
				 Console.WriteLine(x.ToString());
			 }*/

            /*storage.Update(new ReminderItem("Hello World!",
				DateTimeOffset.Now,
				itemGuid,
				"TelegramContact ID"
				));
			list = storage.Get(ReminderItemStatus.Awaiting);
			foreach (ReminderItem x in list)
			{
				Console.WriteLine(x.ToString());
			}*/
        }
        private static void OnReminderItemStatusChange(object sender, ReminderEventStatusChangedEventArgs e)
        {
            Console.WriteLine($"Reminder {e.Reminder.ContactID} now changed status from {e.Reminder.PreviousStatus} to {e.Reminder.Status}!");
        }
        private static void OnReminderItemSendingFailure(object sender, ReminderEventSendingFailedEventArgs e)
        {
            Console.WriteLine($"Reminder {e.Reminder.ContactID} failed to send with exception {e.Reminder.SeenException.Message}!");
        }
        
    }
}
