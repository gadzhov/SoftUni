using System;
using System.Collections.Generic;

namespace _7.Distance_in_Labyrinth
{
    public class Startup
    {
        private static readonly string[,] Matrix =
        {
            {"0", "0", "0", "x", "0", "x"},
            {"0", "x", "0", "x", "0", "x"},
            {"0", "*", "x", "0", "x", "0"},
            {"0", "x", "0", "0", "0", "0"},
            {"0", "0", "0", "x", "x", "0"},
            {"0", "0", "0", "x", "0", "x"}
        };

        private static readonly Queue<Cell> VisitedCells = new Queue<Cell>();

        private static void Main(string[] args)
        {
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

        static void PrintMatrix()
        {
            for (int i = 0; i < Matrix.GetLongLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLongLength(1); j++)
                {
                    Console.Write("{0,4}", Matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static Cell GetStartingPosition()
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