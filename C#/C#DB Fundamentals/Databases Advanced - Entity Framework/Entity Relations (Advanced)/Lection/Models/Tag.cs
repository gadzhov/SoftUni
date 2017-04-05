using System.Collections.Generic;

namespace Lection.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Chirps = new HashSet<Chirp>();
        }
        public string TagRef { get; set; }
        public virtual ICollection<Chirp> Chirps { get; set; }
    }
}
