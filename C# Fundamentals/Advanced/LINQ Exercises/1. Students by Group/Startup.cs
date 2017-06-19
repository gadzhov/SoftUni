using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Students_by_Group
{
    class Startup
    {
        private class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Group { get; set; }
        }
        static void Main(string[] args)
        {
            string input;
            var students = new List<Student>();
            while ((input = Console.ReadLine()) != "END")
            {
                var studentInfo = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var student = new Student()
                {
                    FirstName = studentInfo[0],
                    LastName = studentInfo[1],
                    Group = int.Parse(studentInfo[2])
                };
                students.Add(student);
            }
            students
                .Where(s => s.Group == 2)
                .OrderBy(s => s.FirstName)
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }
    }
}
