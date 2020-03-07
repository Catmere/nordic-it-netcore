using Reminder.Domain.EventArgs;
using Reminder.Domain.EventArgs.Model;
using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Reminder.Domain
{
	public class ReminderDomain
	{
		private IReminderStorage _storage;

		private Timer _awaitingRemindersCheckTimer;
		private Timer _readyToSendRemindersSendTimer;
		public event EventHandler<ReminderEventStatusChangedEventArgs> ReminderItemStatusChanged;
		public event EventHandler<ReminderEventSendingFailedEventArgs> ReminderItemSendingFailed;


		public ReminderDomain(IReminderStorage storage)
		{
			_storage = storage;
			
		}
		public void Run()
		{
			_awaitingRemindersCheckTimer = new Timer(
				CheckAwaitingReminders,
				null,
				TimeSpan.Zero,
				TimeSpan.FromSeconds(1));
			_readyToSendRemindersSendTimer = new Timer(
				SendReadyToSendReminders,
				null,
				TimeSpan.FromSeconds(2),
				TimeSpan.FromSeconds(1));
		}

		private void CheckAwaitingReminders(object _)
		{
			//read items in status Awaiting
			List<ReminderItem> list = _storage.Get(ReminderItemStatus.Awaiting);
			foreach (ReminderItem x in list)
			{
				//check IsTimeToSend, if true
				if (x.IsTimeToSend)
				{
					//update status to ReadyToSend
					ReminderItemStatus buff = x.Status;
					x.Status = ReminderItemStatus.ReadyToSend;
					_storage.Update(x);
					if (ReminderItemStatusChanged != null)
						ReminderItemStatusChanged(this, new ReminderEventStatusChangedEventArgs(new StatusChangedReminderModel(x,buff)));
				}
			}
		}

		private void SendReadyToSendReminders(object _)
		{
			List<ReminderItem> list = _storage.Get(ReminderItemStatus.ReadyToSend);
			foreach (ReminderItem item in list)
			{
				try
				{
					//send
					throw new Exception("test");
					ReminderItemStatus previousStatus = item.Status;
					item.Status = ReminderItemStatus.SuccessfullySent;
					_storage.Update(item);
					if (ReminderItemStatusChanged != null)
						ReminderItemStatusChanged(this, new ReminderEventStatusChangedEventArgs(new StatusChangedReminderModel(item, previousStatus)));
				}
				catch (Exception e)
				{
					//if not sent
					ReminderItemStatus previousStatus = item.Status;
					item.Status = ReminderItemStatus.Failed;
					_storage.Update(item);
					if (ReminderItemSendingFailed != null)
						ReminderItemSendingFailed(this, new ReminderEventSendingFailedEventArgs(new SendingFailedReminderModel(item, previousStatus, e)));
				}
			}
		}
	}
}
