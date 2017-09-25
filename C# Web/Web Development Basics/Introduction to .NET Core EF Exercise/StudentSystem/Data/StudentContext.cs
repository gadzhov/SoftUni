namespace Student_System.Data
{
    using Microsoft.EntityFrameworkCore;
    using Student_System.Models;

    public class StudentContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<Resource> Resourceses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<License> Licenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(LocalDb)\MSSQLLocalDB;Database=StudentSystem;Integrated Security=True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourses>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourses>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Courseses)
                .HasForeignKey(s => s.StudentId);

            modelBuilder.Entity<StudentCourses>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(c => c.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Resourceses)
                .WithOne(r => r.Course)
                .HasForeignKey(r => r.CourseId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Homeworks)
                .WithOne(h => h.Student)
                .HasForeignKey(h => h.StudentId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Homeworks)
                .WithOne(h => h.Course)
                .HasForeignKey(h => h.CourseId);

            modelBuilder.Entity<License>()
                .HasOne(l => l.Resource)
                .WithMany(r => r.Licenses)
                .HasForeignKey(l => l.ResourseId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
