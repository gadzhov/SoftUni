using System.Collections.Generic;

namespace Lection.Models
{
    public class User
    {
        public User()
        {
            this.Chirps = new HashSet<Chirp>();
            this.FriendRequestMade = new HashSet<User>();
            this.FriendRequestsAccepted = new HashSet<User>();
        }
        public int Key { get; set; }
        public string Alias { get; set; }

        public virtual ICollection<Chirp> Chirps { get; set; }

        public int CurrentSessionId { get; set; }
        public virtual ICollection<User> FriendRequestMade { get; set; }
        public virtual ICollection<User> FriendRequestsAccepted { get; set; }
    }
}
