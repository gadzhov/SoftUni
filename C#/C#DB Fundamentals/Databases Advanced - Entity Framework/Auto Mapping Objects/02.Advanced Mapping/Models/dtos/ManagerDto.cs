using System.Collections.Generic;
using System.Text;

namespace _02.Advanced_Mapping.Models
{
    public class ManagerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<EmployeeDto> Subordinates { get; set; }
        public int Count { get; set; }
    }
}
