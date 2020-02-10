using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTimeOffset reminderDateTime;
            string reminderMessage;
            Console.Write("Введите количество будильников:");
            int amountOfReminders = int.Parse(Console.ReadLine());
            ReminderItem[] reminders = new ReminderItem[2];
            for (int i = 0; i < 2; i++)
            {
                Console.Write($"Введите время будильника №{i + 1}:");
                try
                {
                    reminderDateTime = DateTimeOffset.Parse(Console.ReadLine());
                    Console.Write($"Введите сообщение будильника №{i + 1}:");
                    reminderMessage = Console.ReadLine();
                    reminders[i] = new ReminderItem(reminderMessage, reminderDateTime);
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Ошибка {e.Message}, попробуйте еще раз!");
                    i--;
                    continue;
                }                
            }
            for (int i = 0; i < 2; i++)
            {
                reminders[i].WriteProperties();
            }

        }
    }
}
