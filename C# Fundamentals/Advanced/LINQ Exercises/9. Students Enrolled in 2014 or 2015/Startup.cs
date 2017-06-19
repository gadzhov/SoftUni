using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.Students_Enrolled_in_2014_or_2015
{
    class Startup
    {
        static void Main(string[] args)
        {
            string input;
            var students = new List<string[]>();

            while ((input = Console.ReadLine()) != "END")
            {
                students.Add(input
                    .Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries));
            }

            students
                .Where(arr => arr.FirstOrDefault().EndsWith("14") || arr.FirstOrDefault().EndsWith("15"))
                .ToList()                           // Hardcode should be with for cycle
                .ForEach(arr => Console.WriteLine($"{arr[1]} {arr[2]} {arr[3]} {arr[4]}"));
        }
    }
}
