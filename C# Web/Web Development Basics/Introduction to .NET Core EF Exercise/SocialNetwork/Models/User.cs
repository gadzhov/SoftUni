namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using SocialNetwork.Models.Attributes;

    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        [PasswordRequirements]
        public string Password { get; set; }

        [Required]
        [EmailRequirements]
        public string Email { get; set; }

        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = "Maximum allowed file size is {0} bytes")]
        public byte[] ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastLogin { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<UserFriends> Friends { get; set; } = new HashSet<UserFriends>();

        public ICollection<Album> AlbumsOwned { get; set; } = new HashSet<Album>();

        public ICollection<AlbumParticipates> AlbumsParticipate { get; set; } = new HashSet<AlbumParticipates>();
    }
}
