using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку из скобок такого вида: (, ), [, ]: ");
            string input = Console.ReadLine();
			string[] buffArray = input.ToCharArray();
			bool output = true;

            Stack<string> stackOfBrackets = new Stack<string>();
			foreach(string symbol in buffArray)
			{
				if (symbol == "[" || symbol == "(")
					stackOfBrackets.Push(symbol);
				else if(symbol == "]")
				{
					if (stackOfBrackets.Peek() == "[")
						stackOfBrackets.Pop();
					else
						output = false;
				}
				else if (symbol == ")")
				{
					if (stackOfBrackets.Peek() == "(")
						stackOfBrackets.Pop();
					else
						output = false;
				}
				else
				{
					Console.WriteLine("Вы ввели не только скобки!");
					output = false;
					break;
				}

			}

			Console.WriteLine(output);
			Console.ReadKey;
        }
    }
}
