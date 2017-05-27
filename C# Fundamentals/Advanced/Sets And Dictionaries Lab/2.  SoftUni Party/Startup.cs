namespace _2.SoftUni_Party
{
using System;
using System.Collections.Generic;

    class Startup
    {
        static void Main()
        {
            var partyList = new SortedSet<string>();

            var input = Console.ReadLine();

            while (input != "PARTY")
            {
                partyList.Add(input);
                input = Console.ReadLine();
            }

            while (input != "END")
            {
                if (partyList.Contains(input))
                {
                    partyList.Remove(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(partyList.Count);
            foreach (var guest in partyList)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
