using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Models;

namespace Hospital.Models
{
    public class Doctor
    {
        public Doctor()
        {
            this.Visitations = new HashSet<Visitation>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Specialty { get; set; }

        public ICollection<Visitation> Visitations { get; set; }
    }
}
