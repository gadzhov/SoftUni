using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareFrame
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < 1; i++)
            {
                Console.Write("+");
                for (int j = 0; j < n - 2; j++)
                {
                    Console.Write(" -");
                }
                Console.Write(" +");
                Console.WriteLine();
            }
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write("|");
                for (int j = 0; j < n - 2; j++)
                {
                    Console.Write(" -");
                }
                Console.Write(" |");
                Console.WriteLine();
            }
            for (int i = 0; i < 1; i++)
            {
                Console.Write("+");
                for (int j = 0; j < n - 2; j++)
                {
                    Console.Write(" -");
                }
                Console.Write(" +");
                Console.WriteLine();
            }
        }
    }
}
