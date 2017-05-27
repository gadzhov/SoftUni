using System;
using System.Collections.Generic;

namespace _1.Reverse_Strings
{
    class Startup
    {
        static void Main()
        {
            var input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            for (var i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            foreach (var c in stack)
            {
                Console.Write(c);
            }
            Console.WriteLine();
        }
    }
}
