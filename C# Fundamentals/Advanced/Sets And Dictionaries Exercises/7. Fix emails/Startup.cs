using System;
using System.Collections.Generic;

namespace _7.Fix_emails
{
    class Startup
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var emailsDict = new Dictionary<string, string>();

            while (input != "stop")
            {
                var name = input;
                var email = Console.ReadLine();
                if (!email.EndsWith("us") && !email.EndsWith("uk"))
                {
                    emailsDict.Add(name, email);
                }
                input = Console.ReadLine();
            }

            foreach (var person in emailsDict)
            {
                Console.WriteLine($"{person.Key} -> {person.Value}");
            }
        }
    }
}
