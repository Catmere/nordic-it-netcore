using System;
using System.Collections.Generic;
using System.Text;

namespace LessonLiveDemo
{
	public class Circle: IFigure
	{
		public float Radius { get; set; }

		public float GetPerimeter()
		{
			return 2 * MathF.PI * Radius;
		}

		public float GetSquare()
		{
			return MathF.PI * Radius * Radius;
		}

		public Circle(float radius)
		{
			Radius = radius;
		}

		public static bool operator == (Circle circle1, Circle circle2)
		{
			//if (circle1 == null && circle2 == null)
			//{
			//	return true;
			//}

			//if (circle1 == null || circle2 == null)
			//{
			//	return false;
			//}
			
			return circle1.Radius == circle2.Radius;
		}

		public static bool operator !=(Circle circle1, Circle circle2)
		{
			//if (circle1 == null && circle2 == null)
			//{
			//	return false;
			//}

			//if (circle1 == null || circle2 == null)
			//{
			//	return true;
			//}

			return circle1.Radius != circle2.Radius;
		}
	}
}
