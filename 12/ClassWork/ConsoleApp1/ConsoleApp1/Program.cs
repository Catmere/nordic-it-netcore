using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var p1 = new Person()
            {
                Name = "Kirill",
                DateOfBirth = DateTimeOffset.Parse("1997-05-13")
            };
            p1.WriteShortDescription();
            var e1 = new Employee()
            {
                Name = "Kirill",
                DateOfBirth = DateTimeOffset.Parse("1997-05-13"),
                DateOfHiring = DateTimeOffset.Parse("2019-11-10"),
                EmloyeeCode = "12345678"
            };
            e1.WriteShortDescription();*/

            /*var d1 = new BaseDocument(
                "test",
               "101",
                DateTimeOffset.Parse("2020-01-31")
            );
            d1.WriteToConsole();
            var p1 = new Passport(
               "101",
                DateTimeOffset.Parse("2020-01-31"),
                "Russia",
                "Kirill"
            );
            p1.WriteToConsole();*/

            var docs = new BaseDocument[4];
            docs[0] = new BaseDocument(
                "test",
               "101",
                DateTimeOffset.Parse("2020-01-31")
            );
            docs[1] = new Passport(
               "102",
                DateTimeOffset.Parse("2020-01-30"),
                "Russia",
                "Kirill"
            );
            docs[2] = new BaseDocument(
                "test2",
               "103",
                DateTimeOffset.Parse("2020-01-29")
            );
            docs[3] = new Passport(
               "104",
                DateTimeOffset.Parse("2020-01-28"),
                "England",
                "Vadim"
            );
            foreach (BaseDocument doc in docs)
            {
                if (doc is Passport)
                    ((Passport)doc).ChangeIssueDate(DateTimeOffset.Now);
                doc.WriteToConsole();
            }
        }
    }
}

