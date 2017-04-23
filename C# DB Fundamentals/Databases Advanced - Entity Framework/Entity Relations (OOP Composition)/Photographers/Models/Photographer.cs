using System;
using System.Collections.Generic;

namespace Photographers.Models
{
    public class Photographer
    {
        public Photographer()
        {
            this.PhotographerAlbums = new HashSet<PhotographerAlbum>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<PhotographerAlbum> PhotographerAlbums { get; set; }
    }
}
