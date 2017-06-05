using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.Lego_Blocks
{
    class Startup
    {
        static void Main(string[] args)
        {
            var countRows = int.Parse(Console.ReadLine());
            var leftJaggedArray = new int[countRows][];
            var rightJaggedArray = new int[countRows][];

            leftJaggedArray = FillJaggedArray(countRows, leftJaggedArray);
            rightJaggedArray = FillJaggedArray(countRows, rightJaggedArray);
            rightJaggedArray = ReverseJaggedArray(rightJaggedArray);

            var resultArray = new int[countRows][];

            resultArray = ConcateJaggedArrays(leftJaggedArray, rightJaggedArray, countRows);

            var isTwoArraysFit = CheckIsArraysFit(resultArray);

            if (isTwoArraysFit)
            {
                PrintJaggedArray(resultArray);
            }
            else
            {
                var counter = 0;

                foreach (var row in resultArray)
                {
                    counter += row.Length;
                }
                Console.WriteLine($"The total number of cells is: {counter}");
            }


        }

        private static bool CheckIsArraysFit(int[][] resultArray)
        {
            var checker = new HashSet<int>();

            foreach (var row in resultArray)
            {
                checker.Add(row.Length);
            }

            return checker.All(c => c == resultArray[0].Length);
        }

        private static int[][] ConcateJaggedArrays(int[][] leftJaggedArray, int[][] rightJaggedArray, int countRows)
        {
            var concatedArray = new int[countRows][];
            for (int rowIndex = 0; rowIndex < countRows; rowIndex++)
            {
                var tempList = new List<int>();
                tempList.AddRange(leftJaggedArray[rowIndex]);
                tempList.AddRange(rightJaggedArray[rowIndex]);

                concatedArray[rowIndex] = tempList.ToArray();
            }

            return concatedArray;
        }

        private static int[][] ReverseJaggedArray(int[][] rightJaggedArray)
        {
            for (int rowIndex = 0; rowIndex < rightJaggedArray.Length; rowIndex++)
            {
                rightJaggedArray[rowIndex] = rightJaggedArray[rowIndex].Reverse().ToArray();
            }
            return rightJaggedArray;
        }

        private static int[][] FillJaggedArray(int countRows, int[][] jaggedArray)
        {
            for (int rowIndex = 0; rowIndex < countRows; rowIndex++)
            {
                jaggedArray[rowIndex] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }
            return jaggedArray;
        }

        private static void PrintJaggedArray(int[][] jaggedArray)
        {
            foreach (var j in jaggedArray)
            {
                Console.WriteLine("[" + string.Join(", ", j) + "]");
            }
        }
    }
}
