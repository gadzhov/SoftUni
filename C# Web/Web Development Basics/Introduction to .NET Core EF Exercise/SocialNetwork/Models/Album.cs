namespace SocialNetwork.Models
{
    using System.Collections.Generic;
    using SocialNetwork.Models.Enums;

    public class Album
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Colors BackgroundColor { get; set; }

        public bool IsPublic { get; set; }

        public int OwnerId { get; set; }

        public User Owner { get; set; }

        public ICollection<AlbumParticipates> Participants { get; set; } = new HashSet<AlbumParticipates>();

        public ICollection<AlbumPictures> Pictures { get; set; } = new HashSet<AlbumPictures>();

        public ICollection<AlbumTags> Tags { get; set; } = new HashSet<AlbumTags>(); 
    }
}
