using System;
using Problem_6.Generic_Count_Method_Strings.Generics;

namespace Problem_6.Generic_Count_Method_Strings
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

            Console.WriteLine(box.Compare(Console.ReadLine()));
        }
    }
}
