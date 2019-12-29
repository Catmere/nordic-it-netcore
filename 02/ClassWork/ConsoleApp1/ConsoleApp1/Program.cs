using System;
using System.Globalization;
namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			string str;
			do
			{
				Console.WriteLine("Введите радиус");
				float radius = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
				Console.WriteLine(radius * 2 * Math.PI);
				Console.WriteLine("Введите repeat для повтора или Enter для завершения");
				str = Console.ReadLine().ToLower();
				
			} while (str == "repeat");
			
			
		}
	}
}
