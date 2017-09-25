namespace SocialNetwork.Models
{
    using System.Collections.Generic;
    using SocialNetwork.Models.Attributes;

    public class Tag
    {
        public int Id { get; set; }

        [Tag]
        public string Name { get; set; }

        public ICollection<AlbumTags> Albums { get; set; } = new HashSet<AlbumTags>();

        public override string ToString()
        {
            return this.Name;
        }
    }
}
