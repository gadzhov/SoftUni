using System;
using System.Collections.Generic;

namespace _1.Unique_Usernames
{
    class Startup
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var nameSet = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                nameSet.Add(name);
            }

            foreach (var name in nameSet)
            {
                Console.WriteLine(name);
            }
        }
    }
}
