using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Person
    {
        public string Name { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string ShortDescription
        {
            get
            {
                return $"{GetType().Name}: " +
                  $"name: {Name}, " +
                  $"date of birth: {DateOfBirth:dd-MM-yy}";
            }
        }
        public void WriteShortDescription()
        {
            Console.WriteLine(ShortDescription);
        }
    }
}
