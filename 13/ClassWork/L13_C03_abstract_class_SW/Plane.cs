using System;

namespace L13_C05_abstract_members_SW
{
	public class Plane : FlyingObject
	{
		public byte EnginesCount { get; private set; }

		public Plane(int maxHeight, byte enginesCount) : base(maxHeight)
		{
			EnginesCount = enginesCount;
			Console.WriteLine("It’s a plane, welcome aboard!");
		}

		public override void WriteAllProperties()
		{
			base.WriteAllProperties(); // base method call
			Console.WriteLine($"\n\t{nameof(EnginesCount)}:\t{EnginesCount}\n");
		}
	}
}
