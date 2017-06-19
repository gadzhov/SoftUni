using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Students_by_Age
{
    class Startup
    {
        private class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
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
                    LastName = studentInfo[1],
                    Age = int.Parse(studentInfo[2])
                };
                students.Add(student);
            }
            students
                .Where(s => s.Age >= 18 && s.Age <= 24)
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName} {s.Age}"));
        }
    }
}
