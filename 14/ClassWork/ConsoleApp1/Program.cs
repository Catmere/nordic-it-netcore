using System;
using System.IO;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			/*Console.WriteLine(Calculations.Add(1,2));
			Console.WriteLine(Calculations.Multiply(3, 4));*/

			//===================================
			var ErrorList = new ErrorList("normal");

			ErrorList.Add("Houston, we have a problem");
			ErrorList.Add("HOUSTON, IT'S A BIG PROBLEM");

			foreach (string str in ErrorList)
			{
				using (var logger = new LogFileWriterExtended(@".\..\log\log3.txt"))
				{
					logger.WriteLog($"Error category {ErrorList.Category}: {str}");
				}
			}
			ErrorList.WriteToConsole();



			//=====================================
			//Console.WriteLine("Hello World!");
			/*const string filePath = @".\..\log\log.txt";
			var logger = new LogFileWriter(filePath);

			Console.WriteLine(logger.FileName);
			//Console.WriteLine(File.Exists(filePath));
			Console.WriteLine(Path.GetDirectoryName(filePath));
			logger.WriteLog(Path.GetFullPath(logger.FileName));
			logger.WriteLog("Log added");

			var logger2 = new LogFileWriterExtended(@".\..\log\log2.txt");

			Console.WriteLine(logger2.FileName);
			//Console.WriteLine(File.Exists(filePath));
			Console.WriteLine(Path.GetDirectoryName(filePath));
			logger2.WriteLog(Path.GetFullPath(logger2.FileName));
			logger2.WriteLog("Log added");
			logger2.Dispose();

			using (var logger3 = new LogFileWriterExtended(@".\..\log\log2.txt"))
			{
				Console.WriteLine(logger3.FileName);
				//Console.WriteLine(File.Exists(filePath));
				Console.WriteLine(Path.GetDirectoryName(filePath));
				logger3.WriteLog(Path.GetFullPath(logger3.FileName));
				logger3.WriteLog("Log added");
			}
*/

		}
	}
}
