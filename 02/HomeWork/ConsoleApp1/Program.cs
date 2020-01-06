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
                bool typeIsRight; //переменная для повтора цикла
                do
                {
                    Console.WriteLine("Выберите действие (введите название или знак, если он существует):");
                    Console.WriteLine(" сложение;");
                    Console.WriteLine(" вычитание;");
                    Console.WriteLine(" умножение;");
                    Console.WriteLine(" деление;");
                    Console.WriteLine(" остаток от деления;");
                    Console.WriteLine(" возведение в степень.");
                    typeOfCalc = Console.ReadLine().ToLower();
                    typeIsRight = true; //обновляем условие для цикла
                    if (typeOfCalc == "сложение" || typeOfCalc == "+")
                    {
                        result = x + y;
                    }
                    else if (typeOfCalc == "вычитание" || typeOfCalc == "-")
                    {
                        result = x - y;
                    }
                    else if (typeOfCalc == "умножение" || typeOfCalc == "*")
                    {
                        result = x * y;
                    }
                    else if (typeOfCalc == "деление" || typeOfCalc == "/")
                    {
                        result = x / y;
                    }
                    else if (typeOfCalc == "остаток от деления" || typeOfCalc == "остаток")
                    {
                        result = x % y;
                    }
                    else if (typeOfCalc == "возведение в степень" || typeOfCalc == "^")
                    {
                        result = Math.Pow(x, y);
                    }
                    else
                    {
                        Console.WriteLine("Вы не ввели действие. Введите действие или его знак");
                        typeIsRight = false; //если действие не произведено - цикл необходимо повторить
                    }
                } while (typeIsRight == false);
                Console.WriteLine("x = " + x + "; y = " + y + "; действие - " + typeOfCalc + "; ответ - " + result);
                Console.WriteLine("Введите слово \"еще\" для повторного вычисления или Enter для завершения программы");
                doRestart =  Console.ReadLine().ToLower();
            } while (doRestart == "еще");
           
                    








        }
    }
}
