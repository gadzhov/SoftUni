using Projection.Models;

namespace Projection
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
             : base("name=EmployeeContext")
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}