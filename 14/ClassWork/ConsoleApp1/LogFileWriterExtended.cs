using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
	class LogFileWriterExtended: IDisposable
	{
		private readonly StreamWriter _streamWriter;
		public string FileName { get; }
		public LogFileWriterExtended(string fileName)
		{
			FileName = fileName;
			_streamWriter = new StreamWriter(
				File.Open(
					fileName,
				FileMode.Append,
				FileAccess.Write,
				FileShare.None));
		}
		public void WriteLog(string message)
		{
			_streamWriter.WriteLine($"{DateTimeOffset.UtcNow:O}: " + message);
			_streamWriter.Flush();
		}
		public void Dispose()
		{
			_streamWriter?.Dispose();
		}

		
	}
}
