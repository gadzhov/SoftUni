using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection.Models
{
    // Projects & Employees Many to many RS
    public class Project
    {
        public Project()
        {
            Employees = new HashSet<Employee>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
