using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersInReversedOrder
{
    class NumbersInReversedOrder
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(ReturnReverse(input));
        }
        static string ReturnReverse(string input)
        {
            return new string(input.Reverse().ToArray());
        }
    }
}
