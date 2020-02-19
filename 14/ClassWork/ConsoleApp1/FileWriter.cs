using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
	class FileWriter
	{
		public static void WriteLineToFile(string fileName, string message)
		{
			File.WriteAllText(fileName, message);
		}
	}
}
