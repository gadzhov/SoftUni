using System;
using System.Collections;
using System.Linq;

namespace _1.Reverse_Numbers_with_a_Stack
{
    public class Startup
    {
        public static void Main()
        {
            var result = new Stack(Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            Console.WriteLine(string.Join(" ", result.ToArray()));
        }
    }
}
