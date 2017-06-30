using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1___Arrange_Integers
{
    class Startup
    {
        private static readonly string[] IntegerNames = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(str => string.Join(string.Empty, str.Select(ch => IntegerNames[ch - '0'])))));
        }
    }
}
