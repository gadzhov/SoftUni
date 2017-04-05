using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountLettersInString
{
    class CountLettersInString
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine().ToLower();
            //int[] count = new int[input.Max() + 1];
            //foreach (var ch in input)
            //{
            //    count[ch]++;
            //}
            //for (char ch = (char)0; ch < count.Length; ch++)
            //{
            //    if (count[ch] != 0)
            //    {
            //        Console.WriteLine($"{ch} -> {count[ch]}");
            //    }
            //}
            string text = Console.ReadLine().ToLower();
            SortedDictionary<char, int> count = new SortedDictionary<char, int>();
            foreach (char ch in text)
            {
                if (count.ContainsKey(ch))
                {
                    count[ch]++;
                }
                else
                {
                    count[ch] = 1;
                }
            }
            foreach (var item in count.Keys)
            {
                Console.WriteLine($"{item} -> {count[item]}");
            }
        }
    }
}
