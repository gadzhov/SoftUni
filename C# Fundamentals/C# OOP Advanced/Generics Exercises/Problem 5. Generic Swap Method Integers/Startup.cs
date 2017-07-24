using System;
using Problem_5.Generic_Swap_Method_Integers.Generics;

namespace Problem_5.Generic_Swap_Method_Integers
{
    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var box = new Box<int>();

            for (var i = 0; i < n; i++)
            {
                box.Add(int.Parse(Console.ReadLine()));
            }
            var swapPositions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            box.Swap(int.Parse(swapPositions[0]), int.Parse(swapPositions[1]));

            Console.WriteLine(box);
        }
    }
}
