using System;
using System.Linq;

namespace _3.Formatting_Numbers
{
    class Startup
    {
        static void Main(string[] args)
        {
            var inputTokens = Console.ReadLine()
                .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

            var a = int.Parse(inputTokens[0]);
            var binary = Convert.ToString(a, 2).PadLeft(10, '0').Substring(0, 10);
            var b = double.Parse(inputTokens[1]);
            var c = double.Parse(inputTokens[2]);

            Console.WriteLine($"|{a,-10:X}|{binary,10}|{b,10:F2}|{c,-10:F3}|");
        }
    }
}
