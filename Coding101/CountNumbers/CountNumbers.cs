using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountNumbers
{
    class CountNumbers
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int[] counter = new int[input.Max() + 1];
            foreach (var item in input)
            {
                counter[item]++;
            }
            for (int i = 0; i < counter.Length; i++)
            {
                if (counter[i] > 0)
                {
                    Console.WriteLine($"{i} -> {counter[i]}");
                }
            }
        }
    }
}
