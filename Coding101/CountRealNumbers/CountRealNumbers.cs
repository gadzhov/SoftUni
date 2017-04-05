using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountRealNumbers
{
    class CountRealNumbers
    {
        static void Main(string[] args)
        {
            //List<double> numbers = Console.ReadLine()
            //    .Split(' ')
            //    .Select(double.Parse)
            //    .ToList();
            //var count = new SortedDictionary<double, int>();
            //foreach (var num in numbers)
            //{
            //    if (count.ContainsKey(num))
            //    {
            //        count[num]++;
            //    }
            //    else
            //    {
            //        count[num] = 1;
            //    }
            //}
            //foreach (var item in count.Keys)
            //{
            //    Console.WriteLine($"{item} -> {count[item]}");
            //}
            List<double> numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();
            var count = new SortedDictionary<double, int>();
            foreach (var num in numbers)
            {
                if (count.ContainsKey(num))
                {
                    count[num]++;
                }
                else
                {
                    count[num] = 1;
                }
            }
            foreach (var item in count)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
