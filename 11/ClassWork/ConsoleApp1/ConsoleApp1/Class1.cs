using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{

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
	partial class Pet
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
		public string Description
		{
			get { return $"Имя: {Name}, возраст - {Age}, место рождения - {_birthPlace}, дата рождения - {DateOfBirth}"; }
		}

		public Pet() { }

		public Pet(string name, DateTimeOffset dateOfBirth, PetSexes sex, string placeOfBirth)
		{
			Name = name;
			DateOfBirth = dateOfBirth;
			Age = GetAge();
			Sex = sex;
			_birthPlace = placeOfBirth;
		}
		public Pet(string name, int age, PetSexes sex, string placeOfBirth)
		{
			Name = name;
			Age = age;
			SetDateOfBirth(age);
			Sex = sex;
			_birthPlace = placeOfBirth;
		}
		public void SetBirthPlace(string birthPlace)
		{
			_birthPlace = birthPlace;
		}
		public int GetAge()
		{
			Age = Convert.ToInt32((DateTimeOffset.Now - DateOfBirth).Days / 365.242);
			return Age;
		}

		public DateTimeOffset DateOfBirth { get; set; }
		
		public DateTimeOffset SetDateOfBirth(int Age)
		{
			DateOfBirth = DateTimeOffset.Now - TimeSpan.FromDays(365 * Convert.ToDouble(Age));
			return DateOfBirth;
		}
		public string ShortDescription
		{
			get
			{
				return $"Имя: {Name}, возраст - {Age}";
			}
		}
		public void WriteDescription(bool isFullDescription)
		{
			Console.WriteLine(isFullDescription
				? Description
				: ShortDescription);
		}
	}

	partial class Pet
	{

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
	}
}
