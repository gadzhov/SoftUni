using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.List_of_Predicates
{
    class Startup
    {
        static void Main(string[] args)
        {
            var boundary = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<int, bool>[] predicates = numbers.Select(div => (Func<int, bool>)(n => n % div == 0)).ToArray();

            for (int j = 1; j <= boundary; j++)
            {
                bool isDivisable = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(j))
                    {
                        isDivisable = false;
                        break;
                    }
                }

                if (isDivisable)
                {
                    Console.Write($"{j} ");
                }
            }
        }
    }
}
