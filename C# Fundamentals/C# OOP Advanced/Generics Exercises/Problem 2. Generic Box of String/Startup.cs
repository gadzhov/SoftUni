using System;
using Problem_2.Generic_Box_of_String.Generics;

namespace Problem_2.Generic_Box_of_String
{
    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                Console.WriteLine(new Box<string>(Console.ReadLine()));
            }
        }
    }
}
