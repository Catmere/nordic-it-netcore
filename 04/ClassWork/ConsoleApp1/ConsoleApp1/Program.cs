using System;

namespace ConsoleApp1
{
	class Program
	{
		[Flags]
		enum Colours
		{
			Black = 1,
			Blue = 2,
			Cyan = 4,
			Grey = 8,
			Green = 16,
			Magenta = 32,
			Red = 64, 
			White = 128,
			Yellow = 256
		}
		static void Main(string[] args)
		{
			/*double a, n, h;
			Console.Write("Введите длину стороны основания ");
			a = double.Parse(Console.ReadLine());
			Console.Write("Введите высоту ");
			h = double.Parse(Console.ReadLine());
			Console.Write("Введите количество сторон основания ");
			n = double.Parse(Console.ReadLine());
			double k = Math.Sqrt(Math.Pow(h, 2) + Math.Pow(a / (2 * Math.Tan((Math.PI) / n)),2));
			double sFull = ((n * a) / 2 )* (a / (2 * Math.Tan((Math.PI) / n)) + k);
			double sSide = (((n * a) / 2) * k);
			double v = (h * n * Math.Pow(a, 2) / (12 * Math.Tan((Math.PI) / n)));
			Console.WriteLine($"S(бок) = ~{Math.Truncate(sSide*1000)/1000}; S(полн) = ~{Math.Truncate(1000*sFull)/1000}; V = ~{Math.Truncate(1000* v)/1000}");
			Console.ReadKey();*/
					
			Console.WriteLine("Введите 4 любимых цвета через Enter из следующих: ");
			Console.WriteLine("Black,");
			Console.WriteLine("Blue,");
			Console.WriteLine("Cyan,");
			Console.WriteLine("Grey,");
			Console.WriteLine("Green,");
			Console.WriteLine("Magenta,");
			Console.WriteLine("Red,");
			Console.WriteLine("White,");
			Console.WriteLine("Yellow");
			Console.WriteLine();
			Colours allColours = 
				Colours.Black
				| Colours.Blue
				| Colours.Cyan
				| Colours.Green
				| Colours.Grey
				| Colours.Magenta
				| Colours.Red
				| Colours.White
				| Colours.Yellow;


			Colours favouriteColours = 0;
			for(int i = 0; i < 4; i++)
			{
				favouriteColours = (Colours)Enum.Parse(typeof(Colours), Console.ReadLine()) | favouriteColours;
			}
			Console.WriteLine(favouriteColours);
			
			Console.WriteLine(allColours^favouriteColours);
		}
	}
}
