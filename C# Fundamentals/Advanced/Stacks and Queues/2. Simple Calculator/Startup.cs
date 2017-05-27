using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Simple_Calculator
{
    class Startup
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ');
            var stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                var firstNumber = int.Parse(stack.Pop());
                var op = stack.Pop();
                var secondNumber = int.Parse(stack.Pop());
                var sum = 0;
                
                if (op == "+")
                {
                    sum = firstNumber + secondNumber;
                }
                else
                {
                    sum = firstNumber - secondNumber;
                }

                stack.Push(sum.ToString());
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
