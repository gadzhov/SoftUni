using System.Collections.Generic;

namespace Models
{
    public class Movie
    {
        public Movie()
        {
            this.Actors = new HashSet<Actor>();
            this.Genre = new HashSet<Genre>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Genre> Genre { get; set; }
        public int ReleaseYear { get; set; }
        public float Rating { get; set; }
        public int DirectorId { get; set; }
        public int Duration { get; set; }
        public virtual Director Director { get; set; }
        public Studio Studio { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
    }
}
