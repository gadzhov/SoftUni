using System.ComponentModel.DataAnnotations;

namespace PhotographyWorksho.Models
{
    public class Photographer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }
        [RegularExpression(@"\+\d{1,3}\/\d{8,10}", ErrorMessage = "Invalid Phone Number!")]
        public string Phone { get; set; }
    }
}
