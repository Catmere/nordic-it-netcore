using System;

namespace ConsoleApp1
{
    class Program
    {
        
        public enum Figures
        {
            Rectangle = 1,
            Triangle = 2,
            Round = 3
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите тип фигуры:");
            Console.WriteLine(" 1) Прямоугольник;");
            Console.WriteLine(" 2) Равносторонний треугольник;");
            Console.WriteLine(" 3) Круг");
            double square = 0, perimeter = 0;

            try
            {
                Figures chosenFigure = (Figures)Enum.Parse(typeof(Figures), Console.ReadLine());
                switch ((int)chosenFigure)
                {
                    case 1:
                        Console.WriteLine("Введите последовательно ширину и высоту");
                        double width = double.Parse(Console.ReadLine());
                        if (width < 0)
                            throw new Exception("Введено отрицательное значение!");
                        double height = double.Parse(Console.ReadLine());
                        if (height < 0)
                            throw new Exception("Введено отрицательное значение!");
                        square = height * width;
                        perimeter = (height + width) * 2;
                        break;
                    case 2:
                        Console.WriteLine("Введите длину стороны");
                        double side = double.Parse(Console.ReadLine());
                        if (side < 0)
                            throw new Exception("Введено отрицательное значение!");
                        square = (Math.Pow(side, 2) * Math.Sqrt(3)) / 4;
                        perimeter = side * 3;
                        break;
                    case 3:
                        Console.WriteLine("Введите диаметр");
                        double diameter = double.Parse(Console.ReadLine());
                        if (diameter < 0)
                            throw new Exception("Введено отрицательное значение!");
                        square = Math.PI * Math.Pow(diameter / 2, 2);
                        perimeter = Math.PI * diameter;
                        break;
                    default:
                        Console.WriteLine("Вы ввели неверное значение!");
                        return;           
                }
            }
            catch (ArgumentException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введено нечисловое значение!");
                Console.ResetColor();
                throw;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введено нечисловое значение!");
                Console.ResetColor();
                throw;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неизвестная ошибка!");
                Console.ResetColor();
                throw;
            }
            
            Console.WriteLine($"Площадь поверхности: {square}");
            Console.WriteLine($"Длина периметра: {perimeter}");
        }
    }
}
