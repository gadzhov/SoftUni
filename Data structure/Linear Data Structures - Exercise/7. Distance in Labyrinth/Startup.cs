using System;
using System.Collections.Generic;

namespace _7.Distance_in_Labyrinth
{
    public class Startup
    {
        private static string[,] Matrix = new string[0, 0];

        private static readonly Queue<Cell> VisitedCells = new Queue<Cell>();

        public static void Main(string[] args)
        {
            PopulateMetrix();
            Cell startingCell = GetStartingPosition();
            VisitedCells.Enqueue(startingCell);

            while (VisitedCells.Count > 0)
            {
                Cell currentCell = VisitedCells.Dequeue();
                int x = currentCell.X;
                int y = currentCell.Y;
                int value = currentCell.Value + 1;

                VisitCell(new Cell(x, y + 1, value));
                VisitCell(new Cell(x, y - 1, value));
                VisitCell(new Cell(x + 1, y, value));
                VisitCell(new Cell(x - 1, y, value));
            }

            MarkUnreachable();
            PrintMatrix();
        }

        private static void PopulateMetrix()
        {
            var size = int.Parse(Console.ReadLine());
            Matrix = new string[size, size];
            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    Matrix[row, col] = input[col].ToString();
                }
            }
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < Matrix.GetLongLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLongLength(1); j++)
                {
                    Console.Write(Matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static Cell GetStartingPosition()
        {
            for (int i = 0; i < Matrix.GetLongLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLongLength(1); j++)
                {
                    if (Matrix[i, j] == "*")
                    {
                        return new Cell(i, j, 0);
                    }
                }
            }
            throw new AccessViolationException("Missing starting point!");
        }

        static bool AccessibleCell(Cell cell)
        {
            long rows = Matrix.GetLongLength(0);
            long cols = Matrix.GetLongLength(1);
            int row = cell.X;
            int col = cell.Y;

            if (row < 0 || row >= rows || col < 0 || col >= cols || Matrix[row, col] != "0")
            {
                return false;
            }
            return true;
        }

        static void VisitCell(Cell cell)
        {
            if (AccessibleCell(cell))
            {
                VisitedCells.Enqueue(cell);
                Matrix[cell.X, cell.Y] = cell.Value.ToString();
            }
        }

        private static void MarkUnreachable()
        {
            for (int i = 0; i < Matrix.GetLongLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLongLength(1); j++)
                {
                    if (Matrix[i, j] == "0")
                    {
                        Matrix[i, j] = "u";
                    }
                }
            }
        }
    }

    public struct Cell
    {
        public Cell(int x, int y, int value)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
        }

        public int Value { get; private set; }

        public int Y { get; private set; }

        public int X { get; private set; }
    }
}