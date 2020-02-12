using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Passport : BaseDocument
    {

        public new const string DocName = "Passport";

        public string Country { get; set; }
        public string PersonName { get; set; }
        public override string PropertiesString
        {
            get
            {
                return $"Название документа: {DocName}, " +
                    $"номер документа: {DocNumber}, " +
                    $"дата выдачи: {IssueDate:dd-MM-yy}, " +
                    $"страна: {Country}, " +
                    $"имя владельца: {PersonName}";
            }
        }
        public Passport(string docNumber, DateTimeOffset issueDate, string country, string personName) : base(DocName, docNumber, issueDate)
        {
            Country = country;
            PersonName = personName;
        }
        public void ChangeIssueDate(DateTimeOffset newIssueDate)
        {
            IssueDate = newIssueDate;
        }
    }
}
