using System;

namespace ConsoleApp1
{
    class Program
    {
        [Flags]
        enum Containers
        {
            Small = 0x1,
            Medium = 0x1 << 1,
            Big = 0x1 << 2
        }

        static void Main(string[] args)
        {
            string repeatLine = "";
            const string repeater = "repeat";
            do
            {
                Console.WriteLine("Введите объем сока (в литрах), который необходимо упаковать");
                var inputVolume = double.Parse(Console.ReadLine());
                
                const int bigContainerSize = 20, mediumContainerSize = 5;
                int bigContainerAmount = 0, mediumContainerAmount = 0, smallContaineramount = 0;

                bigContainerAmount = Convert.ToInt32(Math.Truncate((Math.Ceiling(inputVolume))/ bigContainerSize)); //сначала доводим до целого, потом обрезаем остаток и преобразовываем в int
                inputVolume -= bigContainerAmount * bigContainerSize;
                if (inputVolume>0)
                {
                    mediumContainerAmount = Convert.ToInt32(Math.Truncate(Math.Ceiling(inputVolume) / mediumContainerSize));
                    inputVolume -= mediumContainerAmount * mediumContainerSize;
                    if (inputVolume > 0)
                    {
                        smallContaineramount = Convert.ToInt32(Math.Truncate(Math.Ceiling(inputVolume)));
                        inputVolume -= Math.Truncate(inputVolume);
                    }
                   
                }
                
                Containers usingContainers = 0;
                if (bigContainerAmount > 0)
                {
                    usingContainers |= Containers.Big;
                }
                if (mediumContainerAmount > 0)
                {
                    usingContainers |= Containers.Medium;
                }
                if (smallContaineramount > 0)
                {
                    usingContainers |= Containers.Small;
                }

                if (usingContainers == 0)
                {
                    Console.WriteLine("Сока нет!");
                } else
                {
                    Console.WriteLine("Потребуются следующие контейнеры:");
                    if ((usingContainers & Containers.Big) == Containers.Big)
                    {
                        Console.WriteLine($"20 л: {bigContainerAmount} шт.");
                    }
                    if ((usingContainers & Containers.Medium) == Containers.Medium)
                    {
                        Console.WriteLine($"5 л: {mediumContainerAmount} шт.");
                    }
                    if ((usingContainers & Containers.Small) == Containers.Small)
                    {
                        Console.WriteLine($"1 л: {smallContaineramount} шт.");
                    }
                }
                
                Console.WriteLine("Введите \"repeat\" для повторения программы");
                repeatLine = Console.ReadLine();
            } while (repeatLine == repeater);

        }
    }
}
