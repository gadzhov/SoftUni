using System;
using System.Linq;

namespace _1.Matrix_of_Palindromes
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ')
                .Select(int.Parse)
                .ToArray();
            var matric = new string[input[0]][];
            var abc = new char[] {'a', 'a', 'a'};

            for (int rowIndex = 0; rowIndex < matric.Length; rowIndex++)
            {
                matric[rowIndex] = new string[input[1]];
                for (int colIndex = 0; colIndex < matric[rowIndex].Length; colIndex++)
                {
                    matric[rowIndex][colIndex] = new string(abc);
                    abc[1]++;
                }
                abc[1] = abc[0];
                abc[0]++;
                abc[1]++;
                abc[2]++;
            }

            foreach (var m in matric)
            {
                Console.WriteLine(string.Join(" ", m));
            }
        }
    }
}
