using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Weak_Students
{
    class Startup
    {
        private class Student
        {
            public Student()
            {
                this.Grades = new List<int>();
            }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public List<int> Grades { get; set; }
        }
        static void Main(string[] args)
        {
            string input;
            var students = new List<Student>();

            while ((input = Console.ReadLine()) != "END")
            {
                var studentsToken = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var fName = studentsToken[0];
                var lName = studentsToken[1];
                var grades = new List<int>();

                for (var i = 2; i < studentsToken.Length; i++)
                {
                    grades.Add(int.Parse(studentsToken[i]));
                }
                students.Add(new Student()
                {
                    FirstName = fName,
                    LastName = lName,
                    Grades = grades
                });
            }

            students
                .Where(s => s.Grades.Count(mark => mark <= 3) >= 2)
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }
    }
}
