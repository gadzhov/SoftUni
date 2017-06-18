using System;
using System.Linq;

namespace _4.Add_VAT
{
    class Startup
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(new []{", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(p => p * 1.2)
                .ToList()
                .ForEach(p => Console.WriteLine($"{p:F2}"));
        }
    }
}
