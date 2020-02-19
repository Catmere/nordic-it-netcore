using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
	class LogFileWriter
	{
		public string FileName { get; }
		public LogFileWriter(string fileName)
		{
			FileName = fileName;
		}
		public void WriteLog(string message)
		{
			var sw = new StreamWriter(
				File.Open(
					FileName,
				FileMode.Append,
				FileAccess.Write,
				FileShare.None));
			sw.WriteLine($"{DateTimeOffset.UtcNow:O}: "+ message);
			sw.Flush();
			sw.Close();
		}
	}
}
