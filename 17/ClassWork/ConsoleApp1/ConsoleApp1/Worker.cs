using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
	class Worker
	{
		public event Action<WorkType, int> OnWorkDone;
		public event Action<WorkType, int, int> OnWorkHourPassed;
		public void DoWork(int hours, WorkType workType)
		{
			Console.WriteLine($"{workType} in progress");
			for (int i = 1; i < hours; i++)
			{
				OnWorkHourPassed?.Invoke(workType, hours, i);
			}
			OnWorkDone?.Invoke(workType, hours);
		}
	}
}
