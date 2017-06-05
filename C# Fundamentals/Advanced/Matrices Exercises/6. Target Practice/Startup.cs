using System;
using System.Linq;

namespace _6.Target_Practice
{
    class Startup
    {
        static void Main(string[] args)
        {
            var matrixDimensions = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var matrix = new char[matrixDimensions[0]][];
            var snake = Console.ReadLine();
            var shotInfo = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            matrix = FillMatrix(matrix, snake, matrixDimensions);
            matrix = ProceedShot(matrix, shotInfo);
            matrix = RunGravity(matrix);


            foreach (var s in matrix)
            {
                Console.WriteLine(string.Join("", s));
            }
        }
        
        private static char[][] FillMatrix(char[][] matrix, string snake, int[] matrixDimensions)
        {
            var counter = 0;
            var rowCounter = 0;
            for (int rowIndex = matrix.Length - 1; rowIndex >= 0; rowIndex--)
            {
                matrix[rowIndex] = new char[matrixDimensions[1]];
                if (rowCounter % 2 == 0)
                {
                    for (int colIndex = matrix[rowIndex].Length - 1; colIndex >= 0; colIndex--)
                    {
                        matrix[rowIndex][colIndex] = snake[counter];

                        counter++;
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }
                    }

                }
                else
                {
                    for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                    {
                        matrix[rowIndex][colIndex] = snake[counter];

                        counter++;
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }
                    }
                }
                rowCounter++;
            }
            return matrix;
        }

        private static char[][] ProceedShot(char[][] matrix, int[] shotInfo)
        {
            var impactRow = shotInfo[0];
            var impactCol = shotInfo[1];
            var radius = shotInfo[2];

            for (var rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (var colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    if (IsCellShot(rowIndex, colIndex, impactRow, impactCol, radius))
                    {
                        matrix[rowIndex][colIndex] = ' ';
                    }
                }
            }

            return matrix;
        }

        private static bool IsCellShot(int row, int col, int impactRow, int imactCol, int radius)
        {
            var valid = (col - imactCol) * (col - imactCol) + (row - impactRow) * (row - impactRow) <= radius * radius;
            return valid;
        }

        private static char[][] RunGravity(char[][] matrix)
        {
            for (int rowIndex = matrix.Length - 1; rowIndex >= 0; rowIndex--)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    if (matrix[rowIndex][colIndex] == ' ')
                    {
                        for (int i = rowIndex - 1; i >= 0; i--)
                        {
                            if (matrix[i][colIndex] != ' ')
                            {
                                matrix[rowIndex][colIndex] = matrix[i][colIndex];
                                matrix[i][colIndex] = ' ';
                                break;
                            }
                        }
                    }
                }
            }

            return matrix;
        }
    }
}
