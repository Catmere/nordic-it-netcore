using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputArray;
            do
            {
                Console.WriteLine("Введите строку из минимум 2 слов:");
                string input = Console.ReadLine();
                inputArray = input.Split();
                if (inputArray.Length < 2)                
                    Console.WriteLine("Слишком мало слов для обработки! Попробуйте еще раз");                
            } while (inputArray.Length < 2);
            int startsWithAAmount = 0;
            foreach (string word in inputArray)
            {
                if (word.StartsWith("а", StringComparison.InvariantCultureIgnoreCase))
                    startsWithAAmount++;                    
            }
            Console.WriteLine($"Количество слов, начинающихся на \'а\': {startsWithAAmount}");
        }
    }
}
