using System;
using System.Linq;

namespace _2.Maximum_sum_of_2x2_submatrix
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var matrix = new int[input[0]][];
            // Fill matrix
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine()
                    .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            var maxSum = int.MinValue;
            var searchedRow = 0;
            var searchedCol = 0;

            for (int rowIndex = 0; rowIndex < matrix.Length - 1; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length - 1; colIndex++)
                {
                    var currentSum = matrix[rowIndex][colIndex] + matrix[rowIndex][colIndex + 1] +
                                     matrix[rowIndex + 1][colIndex] + matrix[rowIndex + 1][colIndex + 1];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        searchedRow = rowIndex;
                        searchedCol = colIndex;
                    }
                }
            }

            Console.WriteLine($"{matrix[searchedRow][searchedCol]} {matrix[searchedRow][searchedCol + 1]}");
            Console.WriteLine($"{matrix[searchedRow + 1][searchedCol]} {matrix[searchedRow + 1][searchedCol + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
