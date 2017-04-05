using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendLists
{
    class AppendLists
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] partOne = input.Split('|');
            List<int> result = new List<int>();
            for (int i = partOne.Length - 1; i >= 0; i--)
            {
                int[] partTwo = partOne[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                foreach (var item in partTwo)
                {
                    result.Add(item);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}