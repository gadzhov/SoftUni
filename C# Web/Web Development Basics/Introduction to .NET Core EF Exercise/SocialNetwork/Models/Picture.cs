namespace SocialNetwork.Models
{
    using System.Collections.Generic;

    public class Picture
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Caption { get; set; }

        public string Path { get; set; }

        public ICollection<AlbumPictures> Albums { get; set; } = new List<AlbumPictures>(); 
    }
}
