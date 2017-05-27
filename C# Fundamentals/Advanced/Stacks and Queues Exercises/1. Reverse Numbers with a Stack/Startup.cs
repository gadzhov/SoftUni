using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Reverse_Numbers_with_a_Stack
{
    class Startup
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
            var stack = new Stack<int>(input);

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }
            Console.WriteLine();
        }
    }
}
