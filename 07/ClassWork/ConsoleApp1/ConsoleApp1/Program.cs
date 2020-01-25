using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			/*Console.WriteLine("Введите два числа: ");
			double a = double.Parse(Console.ReadLine());
			double b = double.Parse(Console.ReadLine());
			Console.WriteLine(a.ToString("#.##") + " * " + b.ToString("#.##") + " = " + (a * b).ToString("#.##"));
			Console.WriteLine(string.Format("{0:#.##} + {1:#.##} = {2:#.##}", a, b, a + b));
			Console.WriteLine($"{a:#.##} - {b:#.##} = {a - b:#.##}");*/

			Console.Write("Введите строку: ");
			string inputLine = Console.ReadLine();
			Console.Write("Введите искомую строку: ");
			string searchedLine = Console.ReadLine();
			string output = "";
			int result = 0;
			do
			{
				result = inputLine.IndexOf(searchedLine, result, StringComparison.OrdinalIgnoreCase);
				if (result == -1)
					break;
				output += result + ", ";
				result++;
			} while (true);
			if (output == "")
				Console.WriteLine("Искомая подстрока не найдена!");
			else
				Console.WriteLine("Индекс подстроки в строке: " + output.TrimEnd(',',' '));

		}
	}
}
