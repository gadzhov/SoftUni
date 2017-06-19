using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Sort_Students
{
    class Startup
    {
        private class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        static void Main(string[] args)
        {
            string input;
            var students = new List<Student>();

            while ((input = Console.ReadLine()) != "END")
            {
                var studentInfo = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                students.Add(new Student()
                {
                    FirstName = studentInfo[0],
                    LastName = studentInfo[1]
                });
            }

            students.OrderBy(s => s.LastName)
                .ThenByDescending(s => s.FirstName)
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }
    }
}
