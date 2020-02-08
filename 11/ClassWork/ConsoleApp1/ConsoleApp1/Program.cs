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
				Age = 8,/*
				DateOfBirth = DateTimeOffset.Parse("2012-06-01"),*/
				Sex = PetSexes.Male
			};
			petFirst.SetDateOfBirth(petFirst.Age);
			petFirst.SetBirthPlace("Moscow");
			Pet petSecond = new Pet("Bobush", 12, PetSexes.Male, "Selyatino");
			/*{
				Name = "Bobush",
				Kind = PetKinds.Dog,
				Age = 12,*//*
				DateOfBirth = DateTimeOffset.Parse("2008-06-01"),*//*
				Sex = PetSexes.Male
			}*/
			/*petSecond.SetDateOfBirth(petSecond.Age);*/
			
			petFirst.WriteDescription(true);
			petSecond.WriteDescription(true);
		}
	}
}
