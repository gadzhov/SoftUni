using System;
using System.Linq;

namespace _3.Group_Numbers
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var result = new int[3][];

            result[0] = input.Where(a => Math.Abs(a) % 3 == 0).ToArray();
            result[1] = input.Where(a => Math.Abs(a) % 3 == 1).ToArray();
            result[2] = input.Where(a => Math.Abs(a) % 3 == 2).ToArray();

            foreach (var row in result)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
