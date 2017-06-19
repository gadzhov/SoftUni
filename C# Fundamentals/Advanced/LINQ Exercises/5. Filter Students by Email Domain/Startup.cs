using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Filter_Students_by_Email_Domain
{
    class Startup
    {
        private class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
        }
        static void Main(string[] args)
        {
            string input;
            var students = new List<Student>();
            while ((input = Console.ReadLine()) != "END")
            {
                var studentInfo = input
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                students.Add(new Student()
                {
                    FirstName = studentInfo[0],
                    LastName = studentInfo[1],
                    Email = studentInfo[2]
                });
            }

            students
                .Where(s => s.Email.EndsWith("@gmail.com"))
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }
    }
}
