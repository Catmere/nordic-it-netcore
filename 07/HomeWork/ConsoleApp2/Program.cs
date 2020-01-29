using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            do
            {
                Console.WriteLine("Введите непустую строку: ");
                input = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input));
            char[] symbols;
            symbols = input.ToLower().ToCharArray();
            string reverseInput = "";
            for (int i = symbols.Length -1; i >= 0; i--)
            {
                reverseInput += symbols[i];
            }
            Console.WriteLine(reverseInput);
        }
    }
}

