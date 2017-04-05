using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            var typeProjection = Console.ReadLine().ToLower();
            var row = int.Parse(Console.ReadLine());
            var culum = int.Parse(Console.ReadLine());
            var price = -1.0;

            if (typeProjection == "premiere")
            {
                price = 12.00;
            }
            else if (typeProjection == "normal")
            {
                price = 7.50;
            }
            else if (typeProjection == "discount")
            {
                price = 5.00;
            }
            Console.WriteLine("{0:f2} leva", price * row * culum);
        }
    }
}
