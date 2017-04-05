using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareCharArrays
{
    class CompareCharArrays
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(' ').ToArray();
            string[] arr2 = Console.ReadLine().Split(' ').ToArray();

            for (int i = 0; i < arr1.Length; i++)
            {
                try
                {
                    if (arr1[i] != arr2[i])
                    {
                        Console.WriteLine(string.Join(" ", ));
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }
    }
}
