﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class FileLogWriter : ILogWriter
    {
        public FileLogWriter()
        {

        }
        public void LogError(string message)
        {
            throw new NotImplementedException();
        }

        public void LogInfo(string message)
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string message)
        {
            throw new NotImplementedException();
        }
    }
}
