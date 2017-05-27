using System;
using System.Collections.Generic;

namespace _6.Math_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var n = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(input);

            var cycle = 1;

            while (queue.Count > 1)
            {
                for (var i = 1; i < n; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                if (PrimeTool.IsPrime(cycle))
                {
                    Console.WriteLine($"Prime {queue.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                }
                cycle++;
            }
            Console.WriteLine($"Last is {queue.Peek()}");

        }
        private static class PrimeTool
        {
            public static bool IsPrime(int candidate)
            {
                // Test whether the parameter is a prime number.
                if ((candidate & 1) == 0)
                {
                    if (candidate == 2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                // Note:
                // ... This version was changed to test the square.
                // ... Original version tested against the square root.
                // ... Also we exclude 1 at the end.
                for (int i = 3; (i * i) <= candidate; i += 2)
                {
                    if ((candidate % i) == 0)
                    {
                        return false;
                    }
                }
                return candidate != 1;
            }
        }
    }
}
