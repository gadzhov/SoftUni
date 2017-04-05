using Exercises.Models;

namespace Exercises.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ExercisesContext : DbContext
    {
        public ExercisesContext()
            : base("name=ExercisesContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ExercisesContext>());
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Standard> Standards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure primary key
            modelBuilder.Entity<Student>().HasKey(s => s.StudentKey);
            modelBuilder.Entity<Standard>().HasKey(s => s.StandardKey);

            //Configure composite primary key
            //modelBuilder.Entity<Student>().HasKey(s => new {s.StudentKey, s.StudentName});

            //Configure Column
            modelBuilder.Entity<Student>()
                .Property(s => s.DateOfBirth)
                .HasColumnName("DoB")
                .HasColumnOrder(3)
                .HasColumnType("datetime2");

            //Configure Null Column
            modelBuilder.Entity<Student>()
                .Property(s => s.Height)
                .IsOptional();

            //Configure NotNull Column
            modelBuilder.Entity<Student>()
                .Property(s => s.Weight)
                .IsRequired();

            //Set StudentName column size to 50
            modelBuilder.Entity<Student>()
                .Property(s => s.StudentName)
                .HasMaxLength(50);

            //Set StudentName column size to 50 and change datatype to nchar 
            //IsFixedLength() change datatype from nvarchar to nchar
            modelBuilder.Entity<Student>()
                .Property(s => s.StudentName)
                .HasMaxLength(50)
                .IsFixedLength();

            //Set size decimal(2,2)
            modelBuilder.Entity<Student>()
                .Property(s => s.Height)
                .HasPrecision(2, 2);

            //Set StudentName as concurrency column
            modelBuilder.Entity<Student>()
                .Property(s => s.StudentName)
                .IsConcurrencyToken();

            //Configure StudentId as PK for StudentAddress
            modelBuilder.Entity<StudentAddress>()
                .HasKey(a => a.StudentId);

            //Configure One-to-Zero-or-One relationship
            //modelBuilder.Entity<Student>()
            //    .HasOptional(s => s.StudentAddress)
            //    .WithRequired(a => a.Student);

            //Configure One-to-One relationship
            modelBuilder.Entity<StudentAddress>()
                .HasRequired(sa => sa.Student)
                .WithRequiredDependent(s => s.StudentAddress);

            //Configure One-to-Many relationship
            modelBuilder.Entity<Student>()
                .HasRequired(s => s.Standard) // Student entity requires Standard 
                .WithMany(st => st.Students)
                .HasForeignKey(s => s.StdId); // Standard entity includes many Students entities

            //configure one-to-many - Alternative
            /*
            modelBuilder.Entity<Standard>()
                        .HasMany<Student>(s => s.Students) //Standard has many Students
                    .WithRequired(s => s.Standard)  //Student require one Standard
                    .HasForeignKey(s => s.StdId); //Student includes specified foreignkey property name for Standard
                    */

            //Configure Many-to - Many relationship
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .Map(cs =>
                {
                    cs.MapLeftKey("StudentRefId");
                    cs.MapRightKey("CourseRefId");
                    cs.ToTable("StudentCourse");
                });


            base.OnModelCreating(modelBuilder);
        }
    }
}