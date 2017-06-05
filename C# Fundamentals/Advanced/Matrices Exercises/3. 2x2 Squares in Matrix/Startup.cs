using System;
using System.Linq;

namespace _3._2x2_Squares_in_Matrix
{
    class Startup
    {
        static void Main(string[] args)
        {
            var matrixDimensions = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var matrix = new string[matrixDimensions[0]][];

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }

            var counter = 0;

            for (int rowIndex = 0; rowIndex < matrix.Length - 1; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length - 1; colIndex++)
                {
                    if (matrix[rowIndex][colIndex] == matrix[rowIndex][colIndex + 1] && matrix[rowIndex][colIndex] == matrix[rowIndex + 1][colIndex] && matrix[rowIndex][colIndex] == matrix[rowIndex + 1][colIndex + 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
