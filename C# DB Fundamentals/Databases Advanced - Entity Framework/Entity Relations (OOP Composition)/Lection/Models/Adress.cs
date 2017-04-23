using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection.Models
{
    // Adress & Student 1 to 1 or 0 RS
    public class Adress
    {
        [Key]
        [ForeignKey("Student")]
        public int Id { get; set; }
        public string Text { get; set; }

        public virtual Student Student { get; set; }
    }
}
