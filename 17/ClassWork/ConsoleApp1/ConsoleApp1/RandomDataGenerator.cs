using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	class RandomDataGenerator
	{
		public event Action<int, int> OnPackComplete;
		public event Action<int> OnMassiveComplete;
		public byte[] GetRandomData(int dataSize, int packSize)
		{
			byte[] result = new byte[dataSize];
			var rand = new Random();
			int amountOfPacks;
			if ((dataSize % packSize) == 0)
			{
				amountOfPacks = dataSize / packSize;
			}
			else
			{
				amountOfPacks = dataSize / packSize + 1;
			}

			for (int i = 0; i < amountOfPacks - 1; i++)
			{
				byte[] middleResult = new byte[packSize];
				rand.NextBytes(middleResult);
				OnPackComplete?.Invoke(i + 1, amountOfPacks);
				for (int j = 0; j < packSize; j++)
				{
					result[j + i * packSize] = middleResult[j];
				}
			}
			if ((dataSize % packSize) != 0)
			{
				for (int i = 0; i < dataSize % packSize; i++)
				{
					byte[] middleResult = new byte[dataSize % packSize];
					rand.NextBytes(middleResult);
					OnPackComplete?.Invoke(i + 1, amountOfPacks);
					for (int j = 0; j < dataSize % packSize; j++)
					{
						result[j + (amountOfPacks - 1) * packSize] = middleResult[j];
					}
				}
			}
			else
			{
				byte[] middleResult = new byte[packSize];
				rand.NextBytes(middleResult);
				OnPackComplete?.Invoke(amountOfPacks, amountOfPacks);
				for (int j = 0; j < packSize; j++)
				{
					result[j + packSize] = middleResult[j];
				}
			}
				
			OnMassiveComplete?.Invoke(amountOfPacks);
			return result;
		}
	}
}
