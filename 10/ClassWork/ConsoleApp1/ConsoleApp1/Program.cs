using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Pet petFirst = new Pet
			{
				Name = "Catmere",
				Kind = PetKinds.Cat,
				Age = 8,
				Sex = PetSexes.Male
			};
			petFirst.SetBirthPlace("Moscow");
			Pet petSecond = new Pet
			{
				Name = "Bobush",
				Kind = PetKinds.Dog,
				Age = 12,
				Sex = PetSexes.Male
			};
			petSecond.SetBirthPlace("Selyatino");
			Console.WriteLine(petFirst.Description);
			Console.WriteLine(petSecond.Description);

			/*Wallet myWallet = new Wallet();
			*//*myWallet.dollarsAmount = 100;
			myWallet.roublesAmount = 6289.25M;*//*

			Console.WriteLine(myWallet.GetRoubles());
			myWallet.AddDollars(100);
			Console.WriteLine(myWallet.GetDollars());
			Console.WriteLine(myWallet.GetRoubles());
			Point point = new Point();
			Point point2 = point;
			point.X = 1.0;
			point.Y = -1.5;
			point.Color = "Red";
			Console.WriteLine(point == point2);
			Console.WriteLine(point.Equals(point2));*/
		}
	}
	enum PetKinds
	{
		Mouse,
		Cat,
		Dog
	}
	enum PetSexes
	{
		Male,
		Female
	}
	class Pet
	{
		private string _birthPlace;
		private int _age;
		private PetSexes _sex;
		public PetKinds Kind;
		public string Name;

		public PetSexes Sex
		{
			get { return _sex; }
			set
			{
				if (value == PetSexes.Male || value == PetSexes.Female)
				{
					_sex = value;
				}
				else
				{
					throw new Exception("The sex is out of range");
				}
			}
		}
		public void SetBirthPlace(string birthPlace)
		{
			 _birthPlace = birthPlace; 
		}
		public int Age
		{
			get
			{
				return _age;
			}
			set
			{
				if (value > 0)
				{
					_age = value;
				}
				else
					throw new Exception("Pet's age cannot be less than zero");
			}
		}
		public string Description
		{
			get { return $"Имя: {Name}, возраст - {Age}, место рождения - {_birthPlace}"; }
		}
	}


	class Wallet
	{
		decimal _money;
		const decimal _roublesRatio = 1;
		const decimal _dollarRatio = 62.89M;

		public decimal GetRoubles()
		{
			return _money / _roublesRatio;
		}
		public decimal GetDollars()
		{
			return _money / _dollarRatio;
		}

		public void AddRoubles(decimal roublesToAdd)
		{
			_money += roublesToAdd * _roublesRatio;
		}

		public void AddDollars(decimal dollarsToAdd)
		{
			_money += (dollarsToAdd * _dollarRatio);
		}
	}
}
