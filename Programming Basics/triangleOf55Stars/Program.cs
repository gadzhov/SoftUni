using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triangleOf55Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 55; i++)
            {
                Console.WriteLine(new string('*', i));
            }
        }
    }
}
