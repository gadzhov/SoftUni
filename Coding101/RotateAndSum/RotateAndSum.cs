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
            int[] arr = Console.ReadLine().Split(' ').Select(a => (int.Parse(a))).ToArray();
            uint kRotate = uint.Parse(Console.ReadLine());
            int[] arrNext = new int[arr.Length];
            int[] sum = new int[arr.Length];
            while (kRotate > 0)
            {
                int n = 1;
                for (int i = 0; i < arr.Length; i++)
                {
                    arrNext[n % arr.Length] = arr[i];
                    n++;
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = arrNext[i];
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
