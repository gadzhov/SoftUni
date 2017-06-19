using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Students_by_First_and_Last_Name
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
                var studentInfo = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var student = new Student()
                {
                    FirstName = studentInfo[0],
                    LastName = studentInfo[1]
                };
                students.Add(student);
            }
            students
                .Where(s => string.Compare(s.FirstName, s.LastName, StringComparison.Ordinal) < 0)
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }
    }
}
