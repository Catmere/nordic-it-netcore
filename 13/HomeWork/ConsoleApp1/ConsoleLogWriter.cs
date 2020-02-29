using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class ConsoleLogWriter : ILogWriter
    {
        public ConsoleLogWriter()
        {
        }
        public void LogError(string message)
        {
            Console.WriteLine($"{DateTimeOffset.UtcNow:O}: Error: " + message);
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"{DateTimeOffset.UtcNow:O}: Info: " + message);
        }

        public void LogWarning(string message)
        {
            Console.WriteLine($"{DateTimeOffset.UtcNow:O}: Warning: " + message);
        }
    }
}
