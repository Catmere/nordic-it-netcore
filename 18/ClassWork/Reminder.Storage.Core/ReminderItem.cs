using System;

namespace Reminder.Storage.Core
{
    public class ReminderItem
    {
        public Guid Id { get; }
        public string ContactID { get; set; }
        public ReminderItemStatus Status { get; set; }
        public DateTimeOffset AlarmDate { get; set; }
        public string AlarmMessage { get; set; }
        public bool IsTimeToSend => TimeToAlarm <= TimeSpan.Zero;
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
                if (TimeToAlarm < TimeSpan.Zero)
                    isOutdated = true;
                else
                    isOutdated = false;
                return isOutdated;
            }
        }
        public ReminderItem(string alarmMessage, DateTimeOffset alarmDate, Guid id, string contactID)
        {
            AlarmDate = alarmDate;
            AlarmMessage = alarmMessage;
            Id = id;
            ContactID = contactID;
            Status = ReminderItemStatus.Awaiting;
        }
        public virtual void WriteProperties()
        {
            string outdated = IsOutdated
                ? "будильник не просрочен"
                : "будильник просрочен";
            Console.WriteLine($"{GetType().Name} - обычное напоминание" +
                $"Дата и время будильника: {AlarmDate}, текст будильника: {AlarmMessage}," +
                $"\nвремя до срабатывания будильника: {TimeToAlarm}, {outdated}");
        }
        public override string ToString()
        {
            return $"{typeof(ReminderItem).Name}; " +
                $"{Id}; " +
                $"Status: {Status}; " +
                $"Fire Date: {AlarmDate:s}; " +
                $"Contact ID: {ContactID}; " +
                $"Message: {AlarmMessage};";
        }
    }
}
