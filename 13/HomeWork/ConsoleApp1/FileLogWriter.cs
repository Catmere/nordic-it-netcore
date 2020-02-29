using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class FileLogWriter : ILogWriter
    {
		private readonly StreamWriter _streamWriter;
		public string FileName { get; }
		public FileLogWriter(string fileName)
		{
			FileName = fileName;
			_streamWriter = new StreamWriter(
				File.Open(
					fileName,
				FileMode.Append,
				FileAccess.Write,
				FileShare.None));
		}
		public void Dispose()
		{
			_streamWriter?.Dispose();
		}
		
        public void LogError(string message)
        {
			_streamWriter.WriteLine($"{DateTimeOffset.UtcNow:O}: Error: " + message);
			_streamWriter.Flush();
		}

        public void LogInfo(string message)
        {
			_streamWriter.WriteLine($"{DateTimeOffset.UtcNow:O}: Info: " + message);
			_streamWriter.Flush();
		}

        public void LogWarning(string message)
        {
			_streamWriter.WriteLine($"{DateTimeOffset.UtcNow:O}: Warning: " + message);
			_streamWriter.Flush();
		}
    }
}
