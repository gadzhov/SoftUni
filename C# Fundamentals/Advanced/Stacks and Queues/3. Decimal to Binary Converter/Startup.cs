using System.Collections.Generic;

namespace _3.Decimal_to_Binary_Converter
{
    using System;

    class Startup
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            if (number == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (number > 0)
                {
                    stack.Push(number % 2);
                    number /= 2;
                }
            }

            foreach (var n in stack)
            {
                Console.Write(n);
            }
        }
    }
}
