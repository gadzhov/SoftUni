using System.Collections.Generic;

namespace Photographers.Models
{
    public class Album
    {
        public Album()
        {
            this.Pictures = new HashSet<Picture>();
            this.Tags = new HashSet<Tag>();
            this.PhotographersAlbums = new HashSet<PhotographerAlbum>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public bool IsPublic { get; set; }

        // public Photographer Photographer { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<PhotographerAlbum> PhotographersAlbums { get; set; }
    }
}
