using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            var shape = Console.ReadLine();
            var area = 0.0;

            if (shape == "square")
            {
                var a = double.Parse(Console.ReadLine());
                area = a * a;
            }
            else if (shape == "circle")
            {
                var r = double.Parse(Console.ReadLine());
                area = Math.PI * r * r;
            }
            else if (shape == "rectangle")
            {
                var a = double.Parse(Console.ReadLine());
                var b = double.Parse(Console.ReadLine());
                area = a * b;
            }
            else if (shape == "triangle")
            {
                var a = double.Parse(Console.ReadLine());
                var h = double.Parse(Console.ReadLine());
                area = (a * h) / 2;
            }
            Console.WriteLine("{0}:f3", area);
        }
    }
}
