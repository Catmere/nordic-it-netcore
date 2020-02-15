using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class ChatReminderItem : ReminderItem
    {
        public string ChatName { get; set; }
        public string AccountName { get; set; }
        public ChatReminderItem(string alarmMessage, DateTimeOffset alarmDate, string chatName, string accountName) : base(alarmMessage, alarmDate)
        {
            ChatName = chatName;
            AccountName = accountName;
        }
        public override void WriteProperties()
        {
            string outdated = IsOutdated
                ? "будильник не просрочен"
                : "будильник просрочен";
            Console.WriteLine($"{GetType().Name} - напоминание для чата" +
                $"\nДата и время будильника: {AlarmDate}, текст будильника: {AlarmMessage}," +
                $"\nвремя до срабатывания будильника: {TimeToAlarm}, {outdated}," +
                $"\nназвание чата: {ChatName}, название аккаунта: {AccountName}");
        }
    }
}
