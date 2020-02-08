using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	public class Randomizer
	{
		public void Randomizerer()
		{
			Random rand = new Random();
			int r = rand.Next();
			Console.WriteLine(r);
		}

	}
}
