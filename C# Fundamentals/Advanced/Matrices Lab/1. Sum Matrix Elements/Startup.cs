using System;
using System.Linq;

namespace _1.Sum_Matrix_Elements
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var sum = 0;

            var matrix = new int[input[0]][];

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine()
                    .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                sum += matrix[rowIndex].Sum();
            }

            Console.WriteLine(matrix.Length);
            Console.WriteLine(matrix[0].Length);
            Console.WriteLine(sum);
        }
    }
}
