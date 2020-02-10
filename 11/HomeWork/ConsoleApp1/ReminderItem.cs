using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class ReminderItem
    {
        public DateTimeOffset AlarmDate { get; set; }
        public string AlarmMessage { get; set; }
        public TimeSpan TimeToAlarm
        {
            get
            {
                return AlarmDate - DateTimeOffset.Now;
            }
        }
        public bool IsOutdated
        {
            get
            {
                bool isOutdated;
                if (TimeToAlarm > TimeSpan.Zero)
                    isOutdated = true;
                else
                    isOutdated = false;
                return isOutdated;
            }
        }
        public ReminderItem()
        {

        }
        public ReminderItem(string alarmMessage, DateTimeOffset alarmDate)
        {
            AlarmDate = alarmDate;
            AlarmMessage = alarmMessage;
        }
        public void WriteProperties()
        {
            string outdated = IsOutdated
                ? "будильник не просрочен"
                : "будильник просрочен";
            Console.WriteLine($"Дата и время будильника: {AlarmDate}, текст будильника: {AlarmMessage}, \nвремя до срабатывания будильника: {TimeToAlarm}, {outdated}");
        }
    }
}
