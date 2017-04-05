using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestCommonEnd
{
    class LargestCommonEnd
    {
        static void Main(string[] args)
        {
            string[] wordsFirst = Console.ReadLine().Split(' ');
            string[] wordsSecond = Console.ReadLine().Split(' ');
            int cntleftRight = 0;
            for (int i = 0; i < wordsFirst.Length && i < wordsSecond.Length; i++)
            {
                if (wordsFirst[i] == wordsSecond[i])
                {
                    cntleftRight++;
                }
            }
            int j = 0;
            int cntRightLeft = 0;
            while (wordsFirst.Length > j && wordsSecond.Length > j)
            {
                if (wordsFirst[wordsFirst.Length - 1 - j] == wordsSecond[wordsSecond.Length - 1 -j])
                {
                    cntRightLeft++;
                }
                j++;
            }
            Console.WriteLine(Math.Max(cntleftRight, cntRightLeft));
        }
    }
}
