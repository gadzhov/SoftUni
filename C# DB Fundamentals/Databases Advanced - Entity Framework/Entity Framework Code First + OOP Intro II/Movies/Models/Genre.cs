using System.Collections.Generic;

namespace Models
{
    public class Genre
    {
        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }
        public int Id { get; set; }
        public string Value { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
