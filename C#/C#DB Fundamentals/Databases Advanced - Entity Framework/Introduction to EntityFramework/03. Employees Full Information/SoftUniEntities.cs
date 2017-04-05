namespace _03.Employees_Full_Information
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SoftUniEntities : DbContext
    {
        public SoftUniEntities()
            : base("name=SoftUniEntities")
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Towns> Towns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>()
                .Property(e => e.AddressText)
                .IsUnicode(false);

            modelBuilder.Entity<Departments>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Departments>()
                .HasMany(e => e.Employees1)
                .WithRequired(e => e.Departments1)
                .HasForeignKey(e => e.DepartmentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.JobTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.Salary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Employees>()
                .HasMany(e => e.Departments)
                .WithRequired(e => e.Employees)
                .HasForeignKey(e => e.ManagerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employees>()
                .HasMany(e => e.Employees1)
                .WithOptional(e => e.Employees2)
                .HasForeignKey(e => e.ManagerID);

            modelBuilder.Entity<Employees>()
                .HasMany(e => e.Projects)
                .WithMany(e => e.Employees)
                .Map(m => m.ToTable("EmployeesProjects").MapLeftKey("EmployeeID").MapRightKey("ProjectID"));

            modelBuilder.Entity<Projects>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Towns>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
