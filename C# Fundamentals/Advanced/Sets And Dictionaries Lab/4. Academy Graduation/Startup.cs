using System.Collections.Generic;

namespace _4.Academy_Graduation
{
    using System.Linq;
    using System;

    class Startup
    {
        static void Main()
        {
            var trackStudents = int.Parse(Console.ReadLine());
            var students = new SortedDictionary<string, double[]>();

            for (int i = 0; i < trackStudents; i++)
            {
                var name = Console.ReadLine();
                var score = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                students.Add(name, score);
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} is graduated with {student.Value.Sum() / student.Value.Count()}");
            }
        }
    }
}
