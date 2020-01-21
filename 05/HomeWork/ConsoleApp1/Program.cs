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
            Console.WriteLine();
            Console.Write("Выбранный тип: ");
            double square, perimeter;

            try
            {
                Figures chosenFigure = (Figures)Enum.Parse(typeof(Figures), Console.ReadLine());
                switch ((int)chosenFigure)
                {
                    case 1:
                        Console.Write("Введите ширину: ");
                        double width = double.Parse(Console.ReadLine());
                        Console.Write("Введите высоту: ");
                        double height = double.Parse(Console.ReadLine());
                        if ((height < 0) || (width < 0))
                            throw new ArgumentOutOfRangeException("Введено отрицательное значение!");
                        else if (height == 0)
                            perimeter = width;
                        else if (width == 0)
                            perimeter = height;
                        else
                            perimeter = (height + width) * 2;
                        square = height * width;                        
                        break;
                    case 2:
                        Console.Write("Введите длину стороны: ");
                        double side = double.Parse(Console.ReadLine());
                        if (side < 0)
                            throw new ArgumentOutOfRangeException("Введено отрицательное значение!");
                        square = (Math.Pow(side, 2) * Math.Sqrt(3)) / 4;
                        perimeter = side * 3;
                        break;
                    case 3:
                        Console.Write("Введите диаметр: ");
                        double diameter = double.Parse(Console.ReadLine());
                        if (diameter < 0)
                            throw new ArgumentOutOfRangeException("Введено отрицательное значение!");
                        square = Math.PI * Math.Pow(diameter / 2, 2);
                        perimeter = Math.PI * diameter;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Введено значение вне заданных границ!");                             
                }
            }
            catch (ArgumentException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
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
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                throw;
            }


            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Площадь поверхности: {Math.Round(square,2)} кв. см");
            Console.WriteLine($"Длина периметра: {Math.Round(perimeter, 2)} см");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
