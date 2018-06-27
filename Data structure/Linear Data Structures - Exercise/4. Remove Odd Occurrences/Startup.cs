using System;
using System.Linq;

namespace _4.Remove_Odd_Occurrences
{
    public class Startup
    {
        public static void Main()
        {
            var elements = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            foreach (var item in elements)
            {
                if (elements.Where(x => x == item).Count() % 2 == 0)
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}
