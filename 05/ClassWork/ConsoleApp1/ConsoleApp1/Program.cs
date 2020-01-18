using System;

namespace ConsoleApp1
{
	class Program
	{
		public enum Color { Red, Green, Blue, Yellow}
		static void Main(string[] args)
		{
			/*do
			{
				*//*Console.WriteLine("Введите срок договора аренды");
				var lengthRent = int.Parse(Console.ReadLine());
				int ending = lengthRent % 10;
				string output = "Договор аренды оформлен на период длительностью ";

				if (lengthRent < 1 || lengthRent > 30)
				{
					Console.WriteLine("Вы ввели неверное значение!");
					continue;
				}

				if ((lengthRent < 10 || lengthRent > 14) && (ending >= 1 && ending <= 4))
				{
					if (ending == 1)
						output += lengthRent + " год";
					else if (ending >= 2 && ending <= 4)
						output += lengthRent + " года";
				}
				else
					output += lengthRent + " лет";

				Console.WriteLine(output);*/

			/*Console.WriteLine("Введите число от 0 до 100");
			int input = 0;
			bool doIf = int.TryParse(Console.ReadLine(), out input);
			if (doIf)
			{
				string output = input < 50
				? "Введенное число меньше 50"
				: "Введенное число больше либо равно 50";
				Console.WriteLine(output);
			}
			else
				Console.WriteLine("Косяк!");*//*

			Console.WriteLine("Введите срок договора аренды");
			var lengthRent = int.Parse(Console.ReadLine());
			int ending = lengthRent % 10;
			string output = "Договор аренды оформлен на период длительностью ";

			if (lengthRent < 1 || lengthRent > 30)
			{
				*//*Console.WriteLine("Вы ввели неверное значение!");
				continue;*//*
				throw new Exception("Введено неверное значение");
			}

			*//*if ((lengthRent < 10 || lengthRent > 14) && (ending >= 1 && ending <= 4))
			{
				if (ending == 1)
					output += lengthRent + " год";
				else if (ending >= 2 && ending <= 4)
					output += lengthRent + " года";
			}
			else
				output += lengthRent + " лет";*//*

			switch (lengthRent)
			{
				case 1:
				case 21:
					output += lengthRent + " год";
					break;
				case 2:
				case 3:
				case 4:
				case 22:
				case 23:
				case 24:
					output += lengthRent + " года";
					break;
				default:
					output += lengthRent + " лет";
					break;
			}
			Console.WriteLine(output);

		} while (Console.ReadLine() == "repeat");*/
			Console.WriteLine("Введите два числа подряд");
			try
			{
				int a = int.Parse(Console.ReadLine());
				int b = int.Parse(Console.ReadLine());
				Console.WriteLine(a / b);
			}
			catch (FormatException e)
			{
				Console.ForegroundColor = ConsoleColor.Red;				
				Console.WriteLine($"{e.Message}");
				Console.ResetColor();
			}
			catch (DivideByZeroException e)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine(e.Message);
				Console.ResetColor();
				Environment.Exit(-1);
				throw;
			}
			
			

		}
	}
}
