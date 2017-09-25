namespace SocialNetwork.Models
{
    public class AlbumTags
    {
        public int AlbumId { get; set; }

        public Album Album { get; set; }

        public int TagId { get; set; }

        public Tag Tag { get; set; }
    }
}
