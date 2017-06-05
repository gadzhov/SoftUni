using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        int[] dimensions = StringToIntArray(Console.ReadLine());
        int rows = dimensions[0];
        int cols = dimensions[1];
        List<List<Cell>> matrix = InitializeMatrix(rows, cols);
        string input = Console.ReadLine();
        while (!input.Equals("Nuke it from orbit"))
        {
            int[] destroyData = StringToIntArray(input);
            int[] coords = new int[] { destroyData[0], destroyData[1] };
            int radius = destroyData[2];

            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    var cell = matrix[i][j];
                    int distance = 0;
                    bool eligibleForDestruction = cell.Row == coords[0] || cell.Col == coords[1];//same row or col
                    if (eligibleForDestruction)
                    {
                        if (cell.Row == coords[0])
                        {
                            distance = Math.Abs(cell.Col - coords[1]);
                        }
                        else // j == coords[1]
                        {
                            distance = Math.Abs(cell.Row - coords[0]);
                        }

                        if (distance <= radius)
                        {
                            matrix[i].Remove(cell);
                            if (cell.Row == coords[0]) // next cell remains at same index
                            {
                                j--;
                            }
                        }
                    }
                }
            }

            ClearUp(matrix);
            input = Console.ReadLine();
        }

        PrintMatrix(matrix);
    }

    private static int[] StringToIntArray(string text)
    {
        return text
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }

    private static List<List<Cell>> InitializeMatrix(int rows, int cols)
    {
        var matrix = new List<List<Cell>>(rows);
        for (int i = 0; i < rows; i++)
        {
            matrix.Add(new List<Cell>(cols));
            for (int j = 0; j < cols; j++)
            {
                matrix[i].Add(new Cell(i, j, i * cols + j + 1));
            }
        }

        return matrix;
    }

    private static void ClearUp(List<List<Cell>> matrix) // remove empty lines and update cell coordinates
    {
        int row = 0;
        while (row < matrix.Count)
        {
            if (matrix[row].Count == 0)
            {
                matrix.RemoveAt(row);
            }
            else
            {
                int col = 0;
                while (col < matrix[row].Count)
                {
                    matrix[row][col].Row = row;
                    matrix[row][col].Col = col++;
                }
                row++;
            }
        }
    }

    private static void PrintMatrix(List<List<Cell>> matrix)
    {
        foreach (var row in matrix)
        {
            foreach (var cell in row)
            {
                Console.Write($"{cell.Value} ");
            }
            Console.WriteLine();
        }
    }
}

class Cell
{
    public int Row { get; set; }
    public int Col { get; set; }
    public int Value { get; set; }

    public Cell(int row, int col, int value)
    {
        this.Row = row;
        this.Col = col;
        this.Value = value;
    }
}