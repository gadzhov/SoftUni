using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestIncreasingSubsequence
{
    class LargestIncreasingSubsequence
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> tmp = new List<int>();
            List<int> result = new List<int>();
            for (int i = 0; i < input.Count - 1; i++)
            {
                if (input[i] == input[i + 1] - 1) 
                {
                    tmp.Add(input[i]);
                    if (tmp.Count > result.Count)
                    {
                        foreach (var item in tmp)
                        {
                            result.Add(item);
                        }
                    }
                }
                else
                {
                    tmp.Clear();
                    if (input[i] == input[i + 1] - 1)
                    {
                        tmp.Add(input[i]);
                        if (tmp.Count > result.Count)
                        {
                            foreach (var item in tmp)
                            {
                                result.Add(item);
                            }
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
