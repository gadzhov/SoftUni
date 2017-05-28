using System;
using System.Collections.Generic;

namespace Problem_5.Phonebook
{
    class Startup
    {
        static void Main(string[] args)
        {
            var phoneBook = new Dictionary<string, string>();
            var input = Console.ReadLine();
            while (input != "search")
            {
                var tokens = input.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0];
                var phoneNumber = tokens[1];

                if (phoneBook.ContainsKey(name))
                {
                    phoneBook[name] = phoneNumber;
                }
                else
                {
                    phoneBook.Add(name, phoneNumber);
                }

                input = Console.ReadLine();

            }

            while (true)
            {
                input = Console.ReadLine();
                if (input == "stop")
                {
                    break;
                }

                if (phoneBook.ContainsKey(input))
                {
                    Console.WriteLine($"{input} -> {phoneBook[input]}");
                }
                else
                {
                    Console.WriteLine($"Contact {input} does not exist.");
                }
            }
        }
    }
}
