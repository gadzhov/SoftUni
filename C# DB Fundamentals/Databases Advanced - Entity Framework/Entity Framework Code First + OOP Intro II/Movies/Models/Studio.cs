using System.Collections.Generic;

namespace Models
{
    public class Studio
    {
        public Studio()
        {
            this.Movies = new HashSet<Movie>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
