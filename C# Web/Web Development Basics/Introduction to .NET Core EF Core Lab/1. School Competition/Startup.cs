namespace _1._School_Competition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _1._School_Competition.Entities;

    public class Startup
    {
        public static void Main()
        {
            Dictionary<string, Student> students = new Dictionary<string, Student>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                // “{student name} {category} {points}”.
                string[] inputArgs = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string studentName = inputArgs[0];
                string category = inputArgs[1];
                int points = int.Parse(inputArgs[2]);

                if (!students.ContainsKey(studentName))
                {
                    Student newStudent = new Student(studentName);
                    students.Add(studentName, newStudent);
                    
                }
                students[studentName].Categories.Add(category);
                students[studentName].TotalPoints += points;
            }

            students.Values
                .OrderByDescending(s => s.TotalPoints)
                .ThenBy(s => s.Name)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
