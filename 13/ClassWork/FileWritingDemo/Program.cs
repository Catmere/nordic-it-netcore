using System;
using System.IO;

namespace FileWritingDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			FileStream fs = File.Open(@"c:\test.txt", FileMode.OpenOrCreate);
			fs.Seek(0, SeekOrigin.End);
			TextWriter tw = new StreamWriter(fs);
			tw.WriteLine("This is a test from C#");
			tw.Close();
			fs.Close();
		}
	}
}
