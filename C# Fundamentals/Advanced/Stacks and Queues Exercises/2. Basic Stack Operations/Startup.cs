using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Basic_Stack_Operations
{
    class Startup
    {
        static void Main()
        {
            var firstInputLine = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var secondInputLine = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var stack = new Stack<int>();

            var n = int.Parse(firstInputLine[0]);
            var pop = int.Parse(firstInputLine[1]);
            var x = int.Parse(firstInputLine[2]);

            // Push elements
            for (int i = 0; i < n; i++)
            {
                stack.Push(secondInputLine[i]);
            }

            // Pop elements
            for (int i = 0; i < pop; i++)
            {
                stack.Pop();
            }

            // Check if x exist in the stack
            var isExist = stack.Contains(x);

            // Print Result true
            if (isExist)
            {
                Console.WriteLine("true");
            }
            // 0
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            // Smallest number in the stack
            else
            {
                var smallest = int.MaxValue;
                while (stack.Count > 0)
                {
                    if (smallest > stack.Peek())
                    {
                        smallest = stack.Pop();
                    }
                    else
                    {
                        stack.Pop();
                    }
                }

                Console.WriteLine(smallest);
            }
        }
    }
}
