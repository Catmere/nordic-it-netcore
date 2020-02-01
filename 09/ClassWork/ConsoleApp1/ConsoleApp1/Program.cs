using System;
using System.Diagnostics;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			const int length = 10000, maxValue = 1000;

			int[] arr = GetInitialArray(length, maxValue);
			//ArrayOutput(arr);

			Stopwatch timer = new Stopwatch();
			timer.Start();
			var sortedArr = SortArray(arr, length);
			timer.Stop();

			Console.WriteLine(timer.ElapsedMilliseconds+"    ==========================================");

			
			timer.Restart();
			Array.Sort(arr);
			timer.Stop();

			Console.WriteLine(timer.ElapsedMilliseconds + "    ==========================================");
			//ArrayOutput(arr);
			//ArrayOutput(sortedArr);

		}
		static int[] GetInitialArray (int count, int maxValue)
		{
			var arr = new int[count];
			var rnd = new Random();

			for (var i = 0; i < arr.Length; i++)
			{
				arr[i] = rnd.Next(maxValue);
			}
			return arr;
		}

		static void ArrayOutput (int[] arrayInt)
		{
			for (var i = 0; i < arrayInt.Length; i++)
			{
				Console.Write(arrayInt[i] + " ");
			}
			Console.WriteLine();
		}

		static int[] SortArray (int[] arrayInt, int gadfga)
		{
			int[] cloneArray = (int[])arrayInt.Clone();
			int buff, counter = 0;

			int clone = gadfga;
			clone++;

			bool isSorted;
			do
			{
				isSorted = true;
				for (var i = 0; i < cloneArray.Length - 1; i++)
				{
					if (cloneArray[i] > cloneArray[i + 1])
					{
						buff = cloneArray[i];
						cloneArray[i] = cloneArray[i + 1];
						cloneArray[i + 1] = buff;
						isSorted = false;
					}
				}

				/*counter++;
				Console.Write(counter + ": ");
				ArrayOutput(cloneArray);*/

			} while (!isSorted);
			return cloneArray;

		}
	}
}
