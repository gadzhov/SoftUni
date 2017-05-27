using System;
using System.Collections.Generic;

namespace _9.Stack_Fibonacci
{
    class Startup
    {
        static void Main(string[] args)
        {
            var stack = new Stack<long>();
            var n = int.Parse(Console.ReadLine());
            stack.Push(0);
            stack.Push(1);
            for (int i = 3; i <= 70; i++)
            {
                var x = stack.Pop();
                var y = stack.Peek();
                stack.Push(x);
                stack.Push(x + y);
            }
            for (int i = 1; i < 70 - n; i++)
            {
                stack.Pop();
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
