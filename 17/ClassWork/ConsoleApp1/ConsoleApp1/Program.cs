using System;

namespace ConsoleApp1
{
	public enum WorkType
	{
		Work,
		DoNothing
	}
	
	class Program
	{

		static void Main(string[] args)
		{
			var randomDataGenerator = new RandomDataGenerator();
			randomDataGenerator.OnPackComplete += (numPack, amountPack) => Console.WriteLine($"Package {numPack} out of {amountPack} packages completed");
			randomDataGenerator.OnMassiveComplete += (amount) => Console.WriteLine($"{amount} packages completed, massive complete!");

			byte[] randomMassive = randomDataGenerator.GetRandomData(8,3);
			foreach(byte n in randomMassive)
			{
				Console.WriteLine(n);
			}
			/*var worker1 = new Worker();
			worker1.OnWorkDone += (workType, hours) => Console.WriteLine($"{workType} done in {hours} hours!");

			worker1.OnWorkHourPassed += Worker1_OnWorkHourPassed;
			worker1.DoWork(5, WorkType.Work);
			worker1.DoWork(2, WorkType.DoNothing);*/

		}

		private static void Worker1_OnWorkHourPassed(WorkType workType, int TotalHours, int hoursPassed)
		{
			Console.WriteLine($"{workType} in progress. Hours spent on {workType}: {hoursPassed} from {TotalHours}");
		}
	}
}
