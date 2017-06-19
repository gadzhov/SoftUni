using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Students_Joined_to_Specialties
{
    class Startup
    {
        private class StudentSpecialty
        {
            public string SpecialityName { get; set; }
            public int FacultyNumber { get; set; }
        }
        private class Student
        {
            public string StudentName { get; set; }
            public int FacultyNumber { get; set; }
        }
        static void Main(string[] args)
        {
            var specialities = new List<StudentSpecialty>();
            var students = new List<Student>();
            string input;

            while ((input = Console.ReadLine()) != "Students:")
            {
                var specialitiesInfo = input.Split(new[] {' '});
                specialities.Add(new StudentSpecialty()
                {
                    SpecialityName = $"{specialitiesInfo[0]} {specialitiesInfo[1]}",
                    FacultyNumber = int.Parse(specialitiesInfo[2])
                });
            }
            while ((input = Console.ReadLine()) != "END")
            {
                var studentInfo = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                students.Add(new Student()
                {
                    StudentName = $"{studentInfo[1]} {studentInfo[2]}",
                    FacultyNumber = int.Parse(studentInfo[0])
                });
            }

            students.Join(specialities, st => st.FacultyNumber, sp => sp.FacultyNumber, (st, sp) => new
                {
                    Name = st.StudentName,
                    FacNum = st.FacultyNumber,
                    Spec = sp.SpecialityName
                })
                .OrderBy(j => j.Name)
                .ToList()
                .ForEach(j => Console.WriteLine($"{j.Name} {j.FacNum} {j.Spec}"));
        }
    }
}
