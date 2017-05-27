using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Truck_Tour
{
    class Startup
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var queue = new Queue<List<int>>();

            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                queue.Enqueue(input);
            }

            var canMakeIt = false;
            for (var i = 0; i < n; i++)
            {
                var fuel = 0;

                foreach (var q in queue)
                {
                    fuel += q[0] - q[1];
                    if (fuel < 0)
                    {
                        canMakeIt = false;
                        break;
                    }
                    canMakeIt = true;
                }
                if (canMakeIt)
                {
                    Console.WriteLine(i);
                    break;
                }
                var helper = queue.Dequeue();
                queue.Enqueue(helper);
            }
        }
    }
}
