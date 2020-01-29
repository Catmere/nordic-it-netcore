using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Stack<string> dishes = new Stack<string>();
			string input = "";
			while (true)
			{
				input = Console.ReadLine();
				if (input.Equals("dry", StringComparison.OrdinalIgnoreCase))
				{
					if (dishes.Count>0)
					{
						dishes.Pop();
					}
					else
					{
						Console.WriteLine("Мытых тарелок нет!");
					}
				}
				else if (input.Equals("wash", StringComparison.OrdinalIgnoreCase))
				{
					dishes.Push(input);
				}
				else if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
				{
					Console.WriteLine($"Количество тарелок в раковине: {dishes.Count}");
					break;
				}
				else
				{
					Console.WriteLine("Не команда!");
				}
				Console.WriteLine($"Количество тарелок в раковине: {dishes.Count}");
			}

			/*Queue<int> numbers = new Queue<int>();

			string input = "";
			Console.WriteLine("Вводите числа");
			while (true)
			{

				input = Console.ReadLine();

				if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
					break;


				if (input.Equals("run", StringComparison.OrdinalIgnoreCase))
				{
					while (numbers.Count > 0)
					{
						Console.WriteLine(Math.Sqrt(numbers.Dequeue()));
					}

					continue;
				}

				try
				{
					numbers.Enqueue(int.Parse(input));
				}
				catch (Exception e)
				{
					Console.WriteLine("Ошибка!");
				}
			}
			Console.WriteLine($"Количество задач в очереди: {numbers.Count}");*/


			/*List<int> intList = new List<int>();
			intList.Add(10);
			intList.Add(20);
			intList.Add(30);
			intList.Add(40);

			Console.WriteLine(string.Join(", ",intList));
			int listNumber = intList.Count;

			var strList = new List<string>();
			strList.Add("One");
			strList.Add("Two");
			strList.Add("Three");
			strList.Add("Four");
			strList.Add("Four");
			strList.Add(null);
			strList.Add(null);

			strList.RemoveAll(i => i == "Four");
			Console.WriteLine(string.Join(", ", strList));*/

			/*Console.WriteLine("Введите числа. Когда заходите прекратить, введите \"stop\"");
			var doubleList = new List<double>();
			double sum = 0, buff = 0;
			try
			{
				do
				{
					string input = Console.ReadLine();
					if (input.ToLower() == "stop")
						break;
					else if (!double.TryParse(input, out buff))
						throw new FormatException("Вы ввели не число!");
					doubleList.Add(buff);
					sum += double.Parse(input);
				} while (true);
			}
			catch(FormatException e)
			{
				Console.WriteLine(e.Message);
				throw;
			}

			double doubleA = sum / doubleList.Count;
			Console.WriteLine($"Сумма: {sum}, среднее: {doubleA}");
			Console.ReadLine();*/

			/*var capitalsOfCountries = new Dictionary<string, string>()
			{
				{"Россия","Москва"},
				{"Франция","Париж"},
				{"Германия","Берлин"},
				{"Италия", "Рим" },
				{"Ватикан","Ватикан" }
			};
			string input = "";
			int score = 0;
			do
			{
				var country = capitalsOfCountries.ElementAt(new Random().Next(capitalsOfCountries.Count()));
				Console.WriteLine($"Введите столицу этой страны: {country.Key}");
				input = Console.ReadLine();
				if (input.Equals(country.Value, StringComparison.OrdinalIgnoreCase))
				{
					score++;
					Console.WriteLine($"Верно!, ваш счет - {score}");
				}
				else
				{
					Console.WriteLine($"Неверно! Столица - {country.Value}, ваш счет - {score}");
					break;
				}
			} while (true);
			Console.WriteLine($"Вы проиграли!");*/


		}
	}
}
