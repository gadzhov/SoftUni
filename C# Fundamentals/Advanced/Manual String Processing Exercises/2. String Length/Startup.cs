using System;

namespace _2.String_Length
{
    class Startup
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            Console.WriteLine(text.PadRight(20, '*'));
        }
    }
}
