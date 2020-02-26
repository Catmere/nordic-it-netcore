using Calculator.Figure;
using Calculator.Operations;
using System;
using System.Drawing;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            const double rad = 1.5, side = 2;

            Image img = Image.FromFile(@"C:\Users\mosco\Desktop\Homework 9\images\cookie.png");
            Console.WriteLine(img.ToString());

            Circle circle = new Circle(rad);
            Console.WriteLine($"Для окружности с радиусом {rad}:");
            Console.WriteLine($"Периметр равен {circle.Calculate(CircleOperations.GetCirclePerimeter)}");
            //Console.WriteLine($"Периметр равен {circle.Calculate(x => 2 * Math.PI * x)}");
            Console.WriteLine($"Площадь равна {circle.Calculate(CircleOperations.GetCircleSquare)}");
            //Console.WriteLine($"Площадь равна {circle.Calculate(x => Math.Pow(x, 2) * Math.PI)}");

            Square square = new Square(side);
            Console.WriteLine($"Для квадрата со стороной {side}:");
            Console.WriteLine($"Периметр равен {square.Calculate(SquareOperations.GetSquarePerimeter)}");
            Console.WriteLine($"Площадь равна {square.Calculate(SquareOperations.GetSquareSquare)}");
        }
        
    }
}
