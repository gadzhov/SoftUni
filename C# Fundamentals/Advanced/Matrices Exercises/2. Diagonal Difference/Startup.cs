using System;
using System.Linq;

namespace _2.Diagonal_Difference
{
    class Startup
    {
        static void Main(string[] args)
        {
            var matricSize = int.Parse(Console.ReadLine());
            var matric = new int[matricSize][];
            var firstDiagonal = 0;
            var secondDiagonal = 0;

            for (int rowIndex = 0; rowIndex < matric.Length; rowIndex++)
            {
                matric[rowIndex] = Console.ReadLine()
                    .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                firstDiagonal += matric[rowIndex][rowIndex];
                secondDiagonal += matric[rowIndex][matricSize - rowIndex - 1];
            }

            Console.WriteLine(Math.Abs(firstDiagonal - secondDiagonal));
        }
    }
}
