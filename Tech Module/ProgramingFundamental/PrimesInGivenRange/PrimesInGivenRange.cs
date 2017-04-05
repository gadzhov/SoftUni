using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimesInGivenRange
{
    class PrimesInGivenRange
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());
            List<int> result = new List<int>();
            FindPrimesInRange(startNum, endNum, result);
        }
        static void FindPrimesInRange(int startNum, int endNum, List<int> result)
        {
            for (int i = startNum; i <= endNum; i++)
            {
                for (int j = (int)Math.Sqrt(endNum); j >= startNum; j--)
                {
                    if (i % j == 0)
                    {
                        continue;
                    }
                    else
                    {
                        result.Add(i);
                        break;
                    }
                }
            }
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
