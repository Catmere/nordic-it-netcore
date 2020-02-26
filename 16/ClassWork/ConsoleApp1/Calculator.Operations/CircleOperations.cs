using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Figure
{
    public class CircleOperations
    {
        public static double GetCircleSquare(double x)
        {
            return Math.Pow(x, 2) * Math.PI;
        }

        public static double GetCirclePerimeter(double x)
        {
            return 2 * Math.PI * x;
        }
    }
}
