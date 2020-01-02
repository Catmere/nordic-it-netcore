using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string doRestart = "";
            do
            {
                Console.WriteLine("Введите x");
                double x = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите y");
                double y = double.Parse(Console.ReadLine());
                string typeOfCalc;
                double result = 0;
                do
                {
                    Console.WriteLine("Выберите действие: сложение, вычитание, умножение, деление, остаток от деления, возведение в степень или введите знак действия, если он существует");
                    typeOfCalc = Console.ReadLine().ToLower();
                    if (typeOfCalc == "сложение" || typeOfCalc == "+")
                    { result = x + y; }
                    else if (typeOfCalc == "вычитание" || typeOfCalc == "-")
                    { result = x - y; }
                    else if (typeOfCalc == "умножение" || typeOfCalc == "*")
                    { result = x * y; }
                    else if (typeOfCalc == "деление" || typeOfCalc == "/")
                    { result = x / y; }
                    else if (typeOfCalc == "остаток от деления" || typeOfCalc == "остаток")
                    { result = x % y; }
                    else if (typeOfCalc == "возведение в степень" || typeOfCalc == "^")
                    { result = Math.Pow(x, y); }
                    else
                    { Console.WriteLine("Вы не ввели действие. Введите действие или его знак"); }
                } while (!(typeOfCalc == "сложение" || typeOfCalc == "+" || typeOfCalc == "вычитание" || typeOfCalc == "-" || typeOfCalc == "умножение" || typeOfCalc == "*" || typeOfCalc == "деление" || typeOfCalc == "/" || typeOfCalc == "остаток от деления" || typeOfCalc == "остаток" || typeOfCalc == "возведение в степень" || typeOfCalc == "^"));
                Console.WriteLine("x = " + x + "; y = " + y + "; действие - " + typeOfCalc + "; ответ - " + result);
                Console.WriteLine("Введите слово \"еще\" для повторного вычисления или Enter для завершения программы");
                doRestart =  Console.ReadLine().ToLower();
            } while (doRestart == "еще");
           
                    








        }
    }
}
