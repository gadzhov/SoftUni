using Lection.Models;

namespace Lection.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class RelationContext : DbContext
    {
      public RelationContext()
            : base("name=RelationContext")
        {
            
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Adress> Adresses { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
    }
}