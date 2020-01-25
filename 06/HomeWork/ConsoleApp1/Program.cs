using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите положительное натуральное число: ");
            string inputString = "";
            bool mistake = true;
            int amountEven = 0;
            while (mistake)
            {
                inputString = Console.ReadLine();
                amountEven = 0;
                try
                {
                    if (inputString == "")
                        throw new Exception("Число не введено!");

                    foreach (char number in inputString)
                    {
                        switch (number.ToString())
                        {
                            case "-":
                                throw new Exception("Число отрицательное!");
                            case ".":
                            case ",":
                                throw new Exception("Число не натуральное!");
                        }

                        if (int.Parse(number.ToString()) % 2 == 0)
                            amountEven++;                        
                    }
                    mistake = false;
                }
                catch (FormatException)
                {
                    Console.Write("Введено нечисловое значение! Попробуйте еще раз: ");
                }
                catch (Exception e)
                {
                    Console.Write(e.Message + " Попробуйте еще раз: ");
                }
            }
            Console.WriteLine($"В числе {inputString} найдено {amountEven} четных чисел");
            Console.ReadKey();
        }
    }
}
