using System;
using System.Linq;
using System.Text;

namespace _1.Reverse_String
{
    class Startup
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var charArray = text.ToCharArray();
            Array.Reverse(charArray);

            Console.WriteLine(charArray);
        }
    }
}
