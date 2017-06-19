using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Filter_Students_by_Phone
{
    class Startup
    {
        private class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
        }
        static void Main(string[] args)
        {
            string input;
            var students = new List<Student>();
            while ((input = Console.ReadLine()) != "END")
            {
                var studentInfo = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                students.Add(new Student()
                {
                    FirstName = studentInfo[0],
                    LastName = studentInfo[1],
                    PhoneNumber = studentInfo[2]
                });
            }

            students
                .Where(s => s.PhoneNumber.StartsWith("+3592") || s.PhoneNumber.StartsWith("02"))
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }
    }
}
