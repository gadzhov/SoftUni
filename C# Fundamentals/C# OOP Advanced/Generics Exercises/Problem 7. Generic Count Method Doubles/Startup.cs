using System;
using Problem_7.Generic_Count_Method_Doubles.Generics;

namespace Problem_7.Generic_Count_Method_Doubles
{
    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var box = new Box<double>();

            for (var i = 0; i < n; i++)
            {
                box.Add(double.Parse(Console.ReadLine()));
            }

            Console.WriteLine(box.Compare(double.Parse(Console.ReadLine())));
        }
    }
}
