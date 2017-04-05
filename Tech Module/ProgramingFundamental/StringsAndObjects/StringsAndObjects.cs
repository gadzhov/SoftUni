using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsAndObjects
{
    class StringsAndObjects
    {
        static void Main(string[] args)
        {
            string one = "Hello";
            string two = "World";
            object concatenation = one + " " + two;
            string third = (string)concatenation;
            Console.WriteLine(third);
        }
    }
}
