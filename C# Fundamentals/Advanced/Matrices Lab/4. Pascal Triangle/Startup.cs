using System;

namespace _4.Pascal_Triangle
{
    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var pascalMatrix = new long[n][];
            for (int rowIndex = 0; rowIndex < pascalMatrix.Length; rowIndex++)
            {
                pascalMatrix[rowIndex] = new long[rowIndex + 1];
                for (int colIndex = 0; colIndex < pascalMatrix[rowIndex].Length; colIndex++)
                {
                    pascalMatrix[rowIndex][0] = 1;
                    pascalMatrix[rowIndex][pascalMatrix[rowIndex].Length - 1] = 1;

                    if (rowIndex >= 2 && colIndex < pascalMatrix[rowIndex].Length - 2)
                    {
                        pascalMatrix[rowIndex][colIndex + 1] = pascalMatrix[rowIndex - 1][colIndex] +
                                                           pascalMatrix[rowIndex - 1][colIndex + 1];
                    }
                }
            }

            foreach (var pascal in pascalMatrix)
            {
                Console.WriteLine(string.Join(" ", pascal));
            }
        }
    }
}
