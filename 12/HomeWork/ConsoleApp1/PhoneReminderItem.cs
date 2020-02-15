using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class PhoneReminderItem : ReminderItem
    {
        public string PhoneNumber { get; set; }
        public PhoneReminderItem(string alarmMessage, DateTimeOffset alarmDate, string phoneNumber) : base(alarmMessage, alarmDate)
        {
            PhoneNumber = phoneNumber;
        }
        public override void WriteProperties()
        {
            string outdated = IsOutdated
                ? "будильник не просрочен"
                : "будильник просрочен";
            Console.WriteLine($"{GetType().Name} - напоминание для телефона" +
                $"Дата и время будильника: {AlarmDate}, текст будильника: {AlarmMessage}," +
                $"\nвремя до срабатывания будильника: {TimeToAlarm}, {outdated}," +
                $"\nномер телефона: {PhoneNumber}");
        }
    }
}
