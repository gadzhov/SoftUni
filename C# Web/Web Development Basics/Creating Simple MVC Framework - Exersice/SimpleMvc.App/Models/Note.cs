namespace SimpleMvc.App.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Note
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Title { get; set; }

        [MaxLength(150)]
        public string Content { get; set; }

        public int OwnerId { get; set; }

        public User Owner { get; set; }
    }
}
