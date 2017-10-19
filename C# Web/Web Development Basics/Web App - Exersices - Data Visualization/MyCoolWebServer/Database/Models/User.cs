namespace MyCoolWebServer.Database.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }
        
        [Required]
        public string Email { get; set; }

        [MinLength(6)]
        [Required]
        public string Password { get; set; }

        [Required]
        public string FullName { get; set; }

        public bool IsAdmin { get; set; } = false;

        public ICollection<GameOwner> Games { get; set; } = new HashSet<GameOwner>();
    }
}
