using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaysOfWeekArray
{
    class DaysOfWeek
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] days = {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
            if (n < 1 || n > days.Length)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(days[n - 1]);
            }
        }
    }
}
