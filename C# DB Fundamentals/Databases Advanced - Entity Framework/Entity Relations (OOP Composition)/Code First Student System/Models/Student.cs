using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Code_First_Student_System.Models;

namespace Code_First_Student_System
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }
        public DateTime BirthDay { get; set; }


        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
