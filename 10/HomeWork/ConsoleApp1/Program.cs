using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			const int amountOfPeople = 3;
			Person[] persons = new Person[amountOfPeople];

			for (int i = 0; i < amountOfPeople; i++)
			{
				persons[i] = new Person();
				try
				{
					persons[i].Input(i);
				}
				catch (Exception e)
				{
					Console.WriteLine($"Ошибка: {e.Message}, попробуйте еще раз!");
					i--;
				}
			}

			for (int i = 0; i < amountOfPeople; i++)
			{
				Console.WriteLine(persons[i].Description);
			}
			Console.ReadKey();
		}
	}
	class Person
	{
		private int _age;
		public string Name { get; set; }
		public int Age
		{
			get { return _age; }
			set
			{
				if (value > 0 && value < 200)
					_age = value;
				else
					throw new Exception("Возраст не может быть меньше 0 или больше 200");
			}
		}
		public int AgeIn4Years(int amountOfYears)
		{
			return _age + amountOfYears;
		}
		public string Description(int amountOfYears)
		{

			return $"Имя: {Name}, возраст через {amountOfYears} года: {MethodAgeIn4Years(amountOfYears)}";
		}
		public void Input(int iteration)
		{
			Console.Write($"Введите имя №{iteration + 1}: ");
			Name = Console.ReadLine();
			Console.Write($"Введите возраст №{iteration + 1}: ");
			Age = int.Parse(Console.ReadLine());
		}
		public int MethodAgeIn4Years(int amountOfYears)
		{
			return Age + amountOfYears;
		}
	}
}
