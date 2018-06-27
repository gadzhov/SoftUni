using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Longest_Subsequence
{
    public class Startup
    {
        public static void Main()
        {
            // 12 2 7 4 3 3 8 => 3 3
            // 2 2 2 3 3 3 => 2 2 2
            Console.WriteLine(Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList()
                .GetLongestSubsequence());
        }
    }

    public static class Extensions
    {
        public static string GetLongestSubsequence<T>(this List<T> list)
        {
            var longestSubSeq = default(T);
            var longestSubSeqCount = 1;

            // Storing the current state in temp variables
            var tempSubSeq = default(T);
            var tempSubSeqCount = 1;

            // Reverse loop to the penultimate element
            for (int i = list.Count - 1; i > 0; i--)
            {
                var item = list[i];
                // On every previous element reseting the temp count to 1
                tempSubSeqCount = 1;
                // Reverse loop from previous element of current to the end
                for (int j = i - 1; j >= 0; j--)
                {
                    if (item.Equals(list[j]))
                    {
                        tempSubSeq = item;
                        tempSubSeqCount++;

                        // Take the longest subsequence
                        if (longestSubSeqCount <= tempSubSeqCount)
                        {
                            longestSubSeq = tempSubSeq;
                            longestSubSeqCount = tempSubSeqCount;
                        }
                    }
                    else
                    {
                        // No subsequence -> reset the count to 0
                        tempSubSeqCount = 0;
                        break;
                    }
                }
            }

            var result = new List<T>();
            for (int i = 0; i < longestSubSeqCount; i++)
            {
                result.Add(longestSubSeq);
            }

            return string.Join(" ", result);
        }
    }
}
