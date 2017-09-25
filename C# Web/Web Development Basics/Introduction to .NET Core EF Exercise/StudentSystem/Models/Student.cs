namespace Student_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Phonenumber { get; set; }

        public DateTime RegistrationTime { get; set; }

        public DateTime? BirthDate { get; set; }

        public ICollection<StudentCourses> Courseses { get; set; } = new List<StudentCourses>();

        public ICollection<Homework> Homeworks { get; set; } = new List<Homework>();
    }
}
