using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Genre = new HashSet<Genre>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int Duration { get; set; }
        public float Rate { get; set; }
        public virtual ICollection<Genre> Genre { get; set; }
        public Director Director { get; set; }
    }
}
