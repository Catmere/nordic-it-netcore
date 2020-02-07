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
			char[] buffArray = input.ToCharArray();
			bool output = true;

			Dictionary<char, char> bracketDictionary = new Dictionary<char, char>();
			bracketDictionary.Add(')', '(');
			bracketDictionary.Add(']', '[');

			Stack<char> stackOfBrackets = new Stack<char>();
			foreach (char symbol in buffArray)
			{
				if (bracketDictionary.ContainsValue(symbol))
				{
					stackOfBrackets.Push(symbol);
				}
				else if (bracketDictionary.ContainsKey(symbol))
				{
					if (stackOfBrackets.Count > 0 && stackOfBrackets.Peek() == bracketDictionary[symbol])
						stackOfBrackets.Pop();
					else
						output = false;
				}
			}
			if (stackOfBrackets.Count > 0)
				output = false;
			Console.WriteLine(output);
			Console.ReadKey();
		}
	}
}
