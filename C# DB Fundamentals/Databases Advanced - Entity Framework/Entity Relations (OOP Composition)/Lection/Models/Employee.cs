using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection.Models
{
    // Self Relation 
    public class Employee
    {
        public Employee()
        {
            Subordinates = new HashSet<Employee>();
            Projects = new HashSet<Project>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual ICollection<Employee> Subordinates { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
