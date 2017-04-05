using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateAMatrix
{
    class RotateAMatrix
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            string[,] matrix = new string[rows, cols];
            string[,] invertMatrix = new string[cols, rows];
            for (int row = 0; row < rows; row++)
            {
                string[] cells = Console.ReadLine().Split(' ').ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = cells[col];
                    invertMatrix[col, row] = matrix[row, col];
                }
            }
            for (int i = 0; i < cols; i++)
            {
                for (int j = rows - 1; j >= 0; j--)
                {
                    Console.Write(invertMatrix[i, j] + " ");
                }
                Console.WriteLine();
            } 
        }
    }
}
