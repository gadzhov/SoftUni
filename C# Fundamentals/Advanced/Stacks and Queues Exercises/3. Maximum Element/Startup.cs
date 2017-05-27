using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Maximum_Element
{
    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var maximum = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                // Push
                if (input[0] == 1)
                {
                    var element = input[1];
                    if (element > maximum)
                    {
                        maximum = element;
                    }
                    stack.Push(element);
                }
                // Pop
                else if (input[0] == 2)
                {
                    var element =  stack.Pop();
                    if (element == maximum && stack.Count > 0)
                    {
                        maximum = stack.Max();
                    }
                }
                // Print the maximum element
                else if (input[0] == 3)
                {
                    Console.WriteLine(maximum);
                }
            }
        }
    }
}
