using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Hot_Potato
{
    class Startup
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ');
            var n = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(input);

            while (queue.Count > 1)
            {
                for (var i = 1; i < n; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}
