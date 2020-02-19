using System;
using System.Runtime.ExceptionServices;

namespace LessonLiveDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			var circle1 = new Circle(1);

			Console.WriteLine(circle1.GetPerimeter());
			Console.WriteLine(circle1.GetSquare());

			var circle2 = new Circle(1);

			Console.WriteLine(circle2.GetPerimeter());
			Console.WriteLine(circle2.GetSquare());

			Console.WriteLine("====");
			Console.WriteLine(circle1 == circle2);
		}
	}
}
