using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = Console.ReadLine().Split(' ').Select(a => int.Parse(a)).ToArray();
            //int[] arrFoldA = new int[arr.Length / 2];
            //int[] arrFoldB = new int[arr.Length / 2];
            //int n = 0;
            //for (int i = arr.Length / 4 - 1; i >= 0; i--)
            //{
            //    arrFoldA[n] = arr[i];
            //    n++;
            //}
            //n = arr.Length / 2 - 1;
            //for (int i = arr.Length - arr.Length / 4; i < arr.Length; i++)
            //{
            //    arrFoldA[n] = arr[i];
            //    n--;
            //}
            //n = 0;
            //int start = arr.Length / 4;
            //int end = arr.Length - arr.Length / 4;
            //for (int i = start; i < end; i++)
            //{
            //    arrFoldB[n] = arr[i];
            //    n++;
            //}
            //int[] sum = new int[arrFoldA.Length];
            //for (int i = 0; i < arrFoldA.Length; i++)
            //{
            //    sum[i] = arrFoldA[i] + arrFoldB[i];
            //}
            //Console.WriteLine(string.Join(" ", sum));

            int[] arr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int k = arr.Length / 4;
            int[] leftSide = arr.Take(k).Reverse().ToArray();
            int[] rightSide = arr.Reverse().Take(k).ToArray();
            int[] rowOne = leftSide.Concat(rightSide).ToArray();
            int[] rowTwo = arr.Skip(k).Take(2 * k).ToArray();
            int[] summArr = rowOne.Select((x, index) => x + rowTwo[index]).ToArray();
            Console.WriteLine(string.Join(" ", summArr));
        }
    }
}
