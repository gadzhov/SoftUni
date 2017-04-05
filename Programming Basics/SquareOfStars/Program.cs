using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            for (int row = 0; row < n; row++)
            {
                Console.Write("*");
                for (int col = 1; col < n; col++)
                {
                    Console.Write(" *");
                }

                Console.WriteLine();
            }
        }
    }
}
