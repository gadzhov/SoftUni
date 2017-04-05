using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Visitation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Comments { get; set; }

        [Required]
        public Patient Patient { get; set; }

        [Required]
        public Doctor Doctor { get; set; }
    }
}
