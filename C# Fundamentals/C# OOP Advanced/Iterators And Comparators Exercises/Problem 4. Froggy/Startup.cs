using System;
using System.Linq;
using Problem_4.Froggy.Models;

namespace Problem_4.Froggy
{
    public class Startup
    {
        public static void Main()
        {
           var lake = new Lake(Console.ReadLine()
               .Split(new [] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray());
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
