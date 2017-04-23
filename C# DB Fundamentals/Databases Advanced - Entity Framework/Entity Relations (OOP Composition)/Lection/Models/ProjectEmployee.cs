using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection.Models
{
    public class ProjectEmployee
    {
        // Explicit maping table
        public DateTime DateJoin { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ProjectId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int EmployeeId { get; set; }

        public virtual Project Project { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
