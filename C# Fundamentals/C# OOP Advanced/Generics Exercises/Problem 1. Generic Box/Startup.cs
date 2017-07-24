using System;
using Problem_1.Generic_Box.Generics;

namespace Problem_1.Generic_Box
{
    public class Startup
    {
        public static void Main()
        {
            var strings = new Box<string>("dwadada");
            Console.WriteLine(strings);
        }
    }
}
