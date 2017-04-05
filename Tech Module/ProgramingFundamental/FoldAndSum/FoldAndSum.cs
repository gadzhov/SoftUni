using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldAndSum
{
    class FoldAndSum
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] foldLeft = new int[array.Length / 2];
            int[] foldResult = new int[array.Length / 2];
            int[] foldMidle = new int[array.Length / 2];

            for (int i = 0; i < foldLeft.Length / 2; i++)
            {
                foldLeft[foldLeft.Length / 2 - i - 1] = array[i];
            }
            int counter = 1;
            for (int i = array.Length / 4; i < foldLeft.Length; i++)
            {
                foldLeft[i] = array[array.Length - counter];
                counter++;
            }

            for (int i = 0; i < foldMidle.Length; i++)
            {
                foldMidle[i] = array[array.Length / 4 + i];
            }

            for (int i = 0; i < foldResult.Length; i++)
            {
                foldResult[i] = foldLeft[i] + foldMidle[i];
            }

            Console.WriteLine(string.Join(" ", foldResult));
        }
    }
}
