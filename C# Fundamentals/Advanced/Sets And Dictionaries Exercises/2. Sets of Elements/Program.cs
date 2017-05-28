using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Sets_of_Elements
{
    class Program
    {
        static void Main()
        {
            var nMTokens = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var n = nMTokens[0];
            var m = nMTokens[1];

            var hashSetN = new HashSet<int>();
            var hashSetM = new HashSet<int>();

            for (var j = 0; j < n; j++)
            {
                var number = int.Parse(Console.ReadLine());
                hashSetN.Add(number);
            }

            for (var j = 0; j < m; j++)
            {
                var number = int.Parse(Console.ReadLine());
                hashSetM.Add(number);
            }

            foreach (var number in hashSetN)
            {
                if (hashSetM.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
