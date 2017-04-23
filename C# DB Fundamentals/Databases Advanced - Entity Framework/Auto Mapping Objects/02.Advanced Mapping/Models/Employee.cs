using System;
using System.Collections.Generic;

namespace _02.Advanced_Mapping.Models
{
    public class Employee
    {
        public Employee()
        {
            this.Subordinates = new HashSet<Employee>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public decimal Salary { get; set; }
        public bool IsOnHoliday { get; set; }
        public string Address { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual ICollection<Employee> Subordinates { get; set; }
    }
}
