using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class BaseDocument
    {
        public string DocName { get; set; }
        public string DocNumber { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public virtual string PropertiesString
        {
            get
            {
                return $"Название документа: {DocName}, " +
                    $"номер документа: {DocNumber}, " +
                    $"дата выдачи: {IssueDate:dd-MM-yy}";
            }
        }
        public BaseDocument(string docName, string docNumber, DateTimeOffset issueDate)
        {
            DocName = docName;
            DocNumber = docNumber;
            IssueDate = issueDate;
        }
        public void WriteToConsole()
        {
            Console.WriteLine(PropertiesString);
        }
    }
}
