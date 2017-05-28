using System;
using System.Collections.Generic;

namespace _6.A_miner_task
{
    class Startup
    {
        static void Main(string[] args)
        {
            var mine = new Dictionary<string, int>();
            var input = Console.ReadLine();

            while (true)
            {
                var resource = input;
                if (input == "stop")
                {
                    break;
                }
                var quantity = int.Parse(Console.ReadLine());

                if (!mine.ContainsKey(resource))
                {
                    mine.Add(resource, quantity);
                }
                else
                {
                    mine[resource] += quantity;
                }
                input = Console.ReadLine();
            }

            foreach (var pair in mine)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
