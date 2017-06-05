using System;
using System.Linq;

namespace _5.Rubik_s_Matrix
{
    class Startup
    {
        static void Main(string[] args)
        {
            var matrixDimensions = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var matrix = new int[matrixDimensions[0]][];

            var startIndex = 1;

            // Initialize the Matrix
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex] = new int[matrixDimensions[1]];
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    matrix[rowIndex][colIndex] = startIndex;
                    startIndex++;
                }
            }
            // Shuffle Cube
            var shuffleTimes = int.Parse(Console.ReadLine());

            while (shuffleTimes != 0)
            {
                var input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var pos = int.Parse(input[0]);
                var direction = input[1];
                var moves = int.Parse(input[2]);

                if (direction == "down")
                {
                    ShuffleDown(pos, moves, matrix);
                }
                else if (direction == "up")
                {
                    ShuffleUp(pos, moves, matrix);
                }
                else if (direction == "left")
                {
                    ShuffleLeft(pos, moves, matrix);
                }
                if (direction == "right")
                {
                    ShuffleRight(pos, moves, matrix);
                }
                shuffleTimes--;
            }

            // Rearange
            var counter = 1;
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    if (matrix[rowIndex][colIndex] == counter)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        var firstDimensions = GetDimensionOfNumber(matrix[rowIndex][colIndex], matrix);
                        var secondDimensions = GetDimensionOfNumber(counter, matrix);
                        var temp = matrix[firstDimensions[0]][firstDimensions[1]];
                        matrix[firstDimensions[0]][firstDimensions[1]] =
                            matrix[secondDimensions[0]][secondDimensions[1]];
                        matrix[secondDimensions[0]][secondDimensions[1]] = temp;
                        Console.WriteLine($"Swap ({firstDimensions[0]}, {firstDimensions[1]}) with ({secondDimensions[0]}, {secondDimensions[1]})");
                    }
                    counter++;
                }
            }

            //foreach (var m in matrix)
            //{
            //    Console.WriteLine(string.Join(" ", m));
            //}
        }

        private static int[] GetDimensionOfNumber(int i, int[][] matrix)
        {
            var result = new int[2];
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    if (matrix[rowIndex][colIndex] == i)
                    {
                        result[0] = rowIndex;
                        result[1] = colIndex;
                        return result;
                    }
                }
            }
            return result;
        }

        private static void ShuffleLeft(int row, int moves, int[][] matrix)
        {
            while (moves > 0)
            {
                var firstTemp = matrix[row][matrix[row].Length - 1];
                matrix[row][matrix[row].Length - 1] = matrix[row][0];
                for (var colIndex = matrix[row].Length - 2; colIndex >= 0; colIndex--)
                {
                    var secondTemp = matrix[row][colIndex];
                    matrix[row][colIndex] = firstTemp;
                    firstTemp = secondTemp;
                }
                moves--;
            }
        }

        private static void ShuffleRight(int row, int moves, int[][] matrix)
        {
            while (moves > 0)
            {
                var firstTemp = matrix[row][0];
                matrix[row][0] = matrix[row][matrix[row].Length - 1];
                for (var colIndex = 1; colIndex < matrix[row].Length; colIndex++)
                {
                    var secondTemp = matrix[row][colIndex];
                    matrix[row][colIndex] = firstTemp;
                    firstTemp = secondTemp;
                }
                moves--;
            }
        }

        private static void ShuffleUp(int col, int moves, int[][] matrix)
        {
            while (moves > 0)
            {
                var firstTemp = matrix[matrix.Length - 1][col];
                matrix[matrix.Length - 1][col] = matrix[0][col];
                for (var rowIndex = matrix.Length - 2; rowIndex >= 0; rowIndex--)
                {
                    var secondTemp = matrix[rowIndex][col];
                    matrix[rowIndex][col] = firstTemp;
                    firstTemp = secondTemp;
                }
                moves--;
            }
        }

        private static void ShuffleDown(int col, int moves, int[][] matrix)
        {
            while (moves > 0)
            {
                var firstTemp = matrix[0][col];
                matrix[0][col] = matrix[matrix.Length - 1][col];
                for (var rowIndex = 1; rowIndex < matrix.Length; rowIndex++)
                {
                    var secondTemp = matrix[rowIndex][col];
                    matrix[rowIndex][col] = firstTemp;
                    firstTemp = secondTemp;
                }
                moves--;
            }
        }
    }
}
