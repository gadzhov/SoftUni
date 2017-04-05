using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int row = 0; row < n; row++)
            {
                for (int col = 1; col < n - row; col++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                for (int col = 0; col < row; col++)
                {
                    Console.Write(" ");
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int row = n - 2; row >= 0; row--)
            {
                for (int col = 1; col < n - row; col++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                for (int col = 0; col < row; col++)
                {
                    Console.Write(" ");
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
