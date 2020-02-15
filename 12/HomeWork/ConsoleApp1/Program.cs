using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTimeOffset reminderDateTime;
            string reminderMessage, reminderPhoneNumber, reminderChatName, reminderAccountName;

            Console.Write("Введите количество напоминаний:");
            long amountOfReminders = long.Parse(Console.ReadLine());
            ReminderItem reminder;
            List<ReminderItem> reminders = new List<ReminderItem>();
            byte reminderType = 0;

            for (int i = 0; i < amountOfReminders; i++)
            {
                Console.WriteLine("Введите номер типа напоминания №{i + 1}:" +
                    "\n1 - обычное напоминание;" +
                    "\n2 - напоминание для чата;" +
                    "\n3 - напоминание для телефона");
                try
                {
                    reminderType = byte.Parse(Console.ReadLine());
                    switch (reminderType)
                    {
                        case 1:
                        case 2:
                        case 3:
                            break;
                        default:
                            throw new Exception("Выбран несуществующий тип напоминания!");
                    }

                    Console.Write($"Введите время напоминания №{i + 1}: ");
                    reminderDateTime = DateTimeOffset.Parse(Console.ReadLine());
                    Console.Write($"Введите сообщение напоминания №{i + 1}: ");
                    reminderMessage = Console.ReadLine();

                    switch (reminderType)
                    {
                        case 1:
                            reminder = new ReminderItem(reminderMessage, reminderDateTime);
                            reminders.Add(reminder);
                            break;
                        case 2:
                            Console.Write("Введите название чата: ");
                            reminderChatName = Console.ReadLine();
                            Console.Write("Введите название аккаунта: ");
                            reminderAccountName = Console.ReadLine();

                            reminder = new ChatReminderItem(reminderMessage, reminderDateTime, reminderChatName, reminderAccountName);
                            reminders.Add(reminder);
                            break;
                        case 3:
                            Console.Write("Введите номер телефона: ");
                            reminderPhoneNumber = Console.ReadLine();

                            reminder = new PhoneReminderItem(reminderMessage, reminderDateTime, reminderPhoneNumber);
                            reminders.Add(reminder);
                            break;
                    }                    
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Ошибка {e.Message}, попробуйте еще раз!");
                    i--;
                    continue;
                }                
            }
            for (int i = 0; i < amountOfReminders; i++)
            {
                Console.WriteLine($"Напоминание №{i + 1}:");
                reminders[i].WriteProperties();
            }

        }
    }
}
