using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateAndSum
{
    class RotateAndSum
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            uint kRotate = uint.Parse(Console.ReadLine());
            int[] arrNext = new int[array.Length];
            int[] sum = new int[array.Length];
            while (kRotate > 0)
            {
                int n = 1;
                for (int i = 0; i < array.Length; i++)
                {
                    arrNext[n % array.Length] = array[i];
                    n++;
                }
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = arrNext[i];
                }
                for (int i = 0; i < arrNext.Length; i++)
                {
                    sum[i] += arrNext[i];
                }
                kRotate--;
            }
            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
