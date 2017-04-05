using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoXTwoSquaresInMatrix
{
    class TwoXTwoSquaresInMatrix
    {
        static void Main(string[] args)
        {
            List<int> size = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int r = size[0];
            int c = size[1];
            int result = 0;
            string[,] matrix = new string[r, c];
            for (int row = 0; row < r; row++)
            {
                List<string> inputRows = Console.ReadLine().Split(' ').ToList();
                for (int col = 0; col < c; col++)
                {
                    matrix[row, col] = inputRows[col];
                }
            }
            for (int i = 0; i < r - 1; i++)
            {
                for (int j = 0; j < c - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1] && matrix[i, j] == matrix[i + 1, j] && matrix[i, j] == matrix[i + 1, j + 1])
                    {
                        result++;
                    }
                }
            }
            Console.WriteLine($"{result}");
        }
    }
}
