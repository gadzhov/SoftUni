using System;
using System.Linq;

namespace _4.Maximal_Sum
{
    class Startup
    {
        static void Main(string[] args)
        {
            var matrixDimensions = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var matrix = new int[matrixDimensions[0]][];

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            var maxSum = int.MinValue;
            var maxPos = new int[2];

            for (int rowIndex = 0; rowIndex < matrix.Length - 2; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length - 2; colIndex++)
                {
                    var currentSum = matrix[rowIndex][colIndex] + matrix[rowIndex][colIndex + 1] +
                                     matrix[rowIndex][colIndex + 2] + matrix[rowIndex + 1][colIndex] +
                                     matrix[rowIndex + 1][colIndex + 1] + matrix[rowIndex + 1][colIndex + 2] +
                                     matrix[rowIndex + 2][colIndex] + matrix[rowIndex + 2][colIndex + 1] +
                                     matrix[rowIndex + 2][colIndex + 2];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxPos[0] = rowIndex;
                        maxPos[1] = colIndex;
                    }
                }

            }
                Console.WriteLine($"Sum = {maxSum}");
                Console.WriteLine($"{matrix[maxPos[0]][maxPos[1]]} {matrix[maxPos[0]][maxPos[1] + 1]} {matrix[maxPos[0]][maxPos[1] + 2]}\n{matrix[maxPos[0] + 1][maxPos[1]]} {matrix[maxPos[0] + 1][maxPos[1] + 1]} {matrix[maxPos[0] + 1][maxPos[1] + 2]}\n{matrix[maxPos[0] + 2][maxPos[1]]} {matrix[maxPos[0] + 2][maxPos[1] + 1]} {matrix[maxPos[0] + 2][maxPos[1] + 2]}");
        }
    }
}
