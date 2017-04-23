using Code_First_Student_System.Migrations;
using Code_First_Student_System.Models;

namespace Code_First_Student_System.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudentContext : DbContext
    {
        public StudentContext()
            : base("name=StudentContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentContext, Configuration>());
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
    }
}