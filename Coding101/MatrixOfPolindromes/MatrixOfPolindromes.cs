using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOfPolindromes
{
    class MatrixOfPolindromes
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int r = nums[0];
            int c = nums[1];
            int palindr = 97;
            char[,] palindromes = new char[r, c];
            for (int row = 97; row < 97 + r; row++)
            {
                for (int col = 97; col < 97 + c; col++)
                {
                    Console.Write($"{(char)row}{(char)palindr}{(char)row} ");
                palindr++;
                }
                Console.WriteLine();
                palindr = row + 1;
            }
        }
    }
}
