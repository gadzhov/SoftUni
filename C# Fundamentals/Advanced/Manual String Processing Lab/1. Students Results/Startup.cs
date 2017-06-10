using System;
using System.Linq;

namespace _1.Students_Results
{
    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine("Name      |   CAdv|   COOP| AdvOOP|Average|");
            for (int rowIndex = 0; rowIndex < n; rowIndex++)
            {
                var inputLine = Console.ReadLine()
                    .Split(new[] { ' ', '-', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var name = inputLine[0];
                var cadv = double.Parse(inputLine[1]);
                var coop = double.Parse(inputLine[2]);
                var advOop = double.Parse(inputLine[3]);
                var average = (cadv + coop + advOop) / 3;
                Console.WriteLine($"{name,-10}|{cadv,7:F2}|{coop,7:F2}|{advOop,7:F2}|{average,7:F4}|");
            }
        }
    }
}
