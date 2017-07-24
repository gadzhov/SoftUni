using System;
using Problem_3.Generic_Box_of_Integer.Generics;

namespace Problem_3.Generic_Box_of_Integer
{
    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new Box<int>(int.Parse(Console.ReadLine())));
            }
        }
    }
}
