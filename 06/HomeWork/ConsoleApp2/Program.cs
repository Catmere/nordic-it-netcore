using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            double contribution = 0;
            double multiplier = 0;
            double desiredAmount = 0;
            int days = 0;
            do
            {
                try
                {
                    Console.Write("Введите сумму взноса в рублях: ");
                    contribution = double.Parse(Console.ReadLine());

                    if (contribution == 0)
                        throw new Exception("С нулевым вкладом вы не достигнете цели!");
                    else if (contribution < 0)
                        throw new Exception("С отрицательным вкладом вы не достигнете цели!");

                    Console.Write("Введите ежедневный процент дохода в виде десятичной дроби: ");
                    multiplier = double.Parse(Console.ReadLine());

                    if (multiplier == 0)
                        throw new Exception("С нулевым доходом вы не достигнете цели!");
                    else if (multiplier < 0)
                        throw new Exception("С отрицательным доходом вы не достигнете цели!");

                    Console.Write("Введите желаемый доход: ");
                    desiredAmount = double.Parse(Console.ReadLine());

                    do
                    {
                        contribution *= (1 + multiplier);
                        days++;
                    } while (desiredAmount >= contribution);
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);                    
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (true);
            

            Console.WriteLine("Количество дней, необходимых для достижения желаемой суммы: " + days);
            Console.ReadKey();
        }
    }
}
