using System;
using System.Collections.Generic;

namespace _4.Matching_Brackets
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }

                if(input[i] == ')')
                {
                    var startIndex = stack.Pop();
                    var expression = input.Substring(startIndex, i - startIndex + 1);

                    Console.WriteLine(expression);
                }

            }
        }
    }
}
