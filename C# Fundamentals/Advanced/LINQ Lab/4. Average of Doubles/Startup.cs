using System;
using System.Linq;

namespace _4.Average_of_Doubles
{
    class Startup
    {
        static void Main(string[] args)
        {
            var average = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Average();
        Console.WriteLine($"{average:F2}");
        }
    }
}
