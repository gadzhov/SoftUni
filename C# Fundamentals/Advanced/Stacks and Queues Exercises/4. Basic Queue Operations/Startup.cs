using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Basic_Queue_Operations
{
    class Startup
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var n = input[0];
            var s = input[1];
            var x = input[2];

            var elements = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var queue = new Queue<int>();

            // Enqueue
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(elements[i]);
            }

            // Dequeue
            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
        }
    }
}
