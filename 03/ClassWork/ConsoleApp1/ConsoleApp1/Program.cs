using System;
using System.Threading;
using System.Globalization;
using System.Text;
using ConsoleApp1.Properties;


namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.InputEncoding = Encoding.ASCII;
			Console.OutputEncoding = Encoding.Unicode;
			
			if (args != null && args.Length >0)
			{
				Thread.CurrentThread.CurrentCulture
					= Thread.CurrentThread.CurrentUICulture
						= CultureInfo.GetCultureInfo(args[0]);
			}
			else
			{
				Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
				Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
			}
			/*Console.Write(Resources.NumberPrompt);
			string input = Console.ReadLine();
			Console.WriteLine(input.Trim());
			double? x = double.Parse(input.Trim());
			Console.WriteLine(Resources.Result + x * x);*/

			//Arrays

			int[] integerArray = new int[3];
			integerArray[0] = 1;
			integerArray[1] = 2;
			integerArray[2] = 3;

			for (int i = 0; i < integerArray.Length; i++)
			{
				Console.WriteLine(integerArray[i]);
			}
		}
	}
}
