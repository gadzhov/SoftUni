namespace SocialNetwork.Models
{
    public class AlbumParticipates
    {
        public int AlbumId { get; set; }

        public Album Album { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
