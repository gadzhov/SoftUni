using System.Collections.Generic;

namespace Photographers.Models
{
    public class Picture
    {
        public Picture()
        {
            this.Albums = new HashSet<Album>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Caption { get; set; }
        public string PicturePath { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
