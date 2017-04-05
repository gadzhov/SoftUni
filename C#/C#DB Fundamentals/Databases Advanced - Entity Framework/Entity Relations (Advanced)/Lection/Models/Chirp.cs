using System.Collections.Generic;

namespace Lection.Models
{
    public class Chirp
    {
        public Chirp()
        {
            this.Comments = new HashSet<Comment>();
            this.Tags = new HashSet<Tag>();
        }
        public int Id { get; set; }
        public string Content { get; set; }

        public int AuthorId { get; set; }
        public virtual User Author { get; set; }
        public virtual ChImg Image { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
