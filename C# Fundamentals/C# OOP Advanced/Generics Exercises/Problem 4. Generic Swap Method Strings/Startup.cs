using System;
using Problem_4.Generic_Swap_Method_Strings.Generics;

namespace Problem_4.Generic_Swap_Method_Strings
{
    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var box = new Box<string>();

            for (var i = 0; i < n; i++)
            {
                box.Add(Console.ReadLine());
            }
            var swapPositions = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            box.Swap(int.Parse(swapPositions[0]), int.Parse(swapPositions[1]));

            Console.WriteLine(box);
        }
    }
}
