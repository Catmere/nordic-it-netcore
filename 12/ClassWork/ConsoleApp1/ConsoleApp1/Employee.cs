using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Employee : Person
    {
        public string EmloyeeCode { get; set; }
        public DateTimeOffset DateOfHiring { get; set; }
        public new string ShortDescription
        {
            get
            {
                return $"{GetType().Name}: " +
                  $"name: {Name}, " +
                  $"date of birth: {DateOfBirth:dd-MM-yy}, " +
                  $"employee code {EmloyeeCode}, " +
                  $"date of hiring {DateOfHiring:dd-MM-yy}";
            }
        }
        public new void WriteShortDescription()
        {
            Console.WriteLine(ShortDescription);
        }
    }
}
