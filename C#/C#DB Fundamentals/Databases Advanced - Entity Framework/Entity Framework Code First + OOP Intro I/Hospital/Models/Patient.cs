using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public byte[] Picture { get; set; }

        [Required]
        public bool HasMedicalEnsurance { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }
        public virtual ICollection<Diagnose> Diagnoses { get; set; }
        public virtual ICollection<Medicament> Medicaments { get; set; }
    }
}
