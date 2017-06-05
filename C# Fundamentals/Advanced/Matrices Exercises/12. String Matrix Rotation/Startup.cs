using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringMatrixRotationProblem2
{
    class StringMatrixRotation
    {

        static void Main()
        {
            string command = Console.ReadLine();
            int first = command.IndexOf("(");
            int last = command.IndexOf(")");
            int lenght = last - first;
            string number = command.Substring(first + 1, lenght - 1);
            int degrees = int.Parse(number);
            List<string> l = new List<string>();
            int maxLength = 0;
            int rows = 0;
            string input = Console.ReadLine();
            while (input != "END")
            {
                rows++;
                l.Add(input);
                if (input.Length > maxLength)
                {
                    maxLength = input.Length;
                }
                input = Console.ReadLine();
            }
            char[,] matrix = new char[rows, maxLength];
            int index = 0;
            int item = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string word = l[item];
                int itemLength = word.Length;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (index == itemLength)
                    {
                        while (index < maxLength)
                        {
                            matrix[row, col] = ' ';
                            index++;
                            col++;
                        }
                        index = 0;
                        break;
                    }
                    else
                    {
                        matrix[row, col] = word[index];
                        index++;
                    }
                }
                item++;
                index = 0;


            }
            Rotate(matrix, degrees);
        }
        static void Rotate(char[,] m, int degrees)
        {
            degrees %= 360;
            switch (degrees)
            {
                case 0:
                   for (int row = 0; row < m.GetLength(0); row++)
                        {
                            for (int col = 0; col < m.GetLength(1); col++)
                            {
                                Console.Write(m[row, col]);
                            }
                            Console.WriteLine();
                        }
                   break;
                    
                case 90:

                    for (int col = 0; col < m.GetLength(1); col++)
                    {
                        for (int row = m.GetLength(0) - 1; row >= 0; row--)
                        {
                            Console.Write(m[row, col]);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 180:
                    for (int r = m.GetLength(0) - 1; r >= 0; r--)
                    {
                        for (int c = m.GetLength(1) - 1; c >= 0; c--)
                        {
                            Console.Write(m[r, c]);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 270:
                    for (int col = m.GetLength(1) - 1; col >= 0; col--)
                    {
                        for (int row = 0; row <= m.GetLength(0) - 1; row++)
                        {
                            Console.Write(m[row, col]);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 360:
                    for (int row = 0; row < m.GetLongLength(0); row++)
                    {
                        for (int col = 0; col < m.GetLongLength(1); col++)
                        {
                            Console.Write(m[row, col]);
                        }
                        Console.WriteLine();
                    }
                    break;
            }

        }
    }
}