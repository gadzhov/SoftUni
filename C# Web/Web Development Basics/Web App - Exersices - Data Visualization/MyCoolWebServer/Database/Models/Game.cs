namespace MyCoolWebServer.Database.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Trailer { get; set; }

        public string ImageThumbnail { get; set; }

        [Required]
        public double Size { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ICollection<GameOwner> Owners { get; set; } = new HashSet<GameOwner>();
    }
}
