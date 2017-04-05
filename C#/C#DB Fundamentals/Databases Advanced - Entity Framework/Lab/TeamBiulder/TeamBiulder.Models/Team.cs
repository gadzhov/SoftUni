using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamBiulder.Models
{
    public class Team
    {
        public Team()
        {
            this.Members = new HashSet<User>();
            this.ParticipatingEvents = new HashSet<Event>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [MinLength(3)]
        public string Acronym { get; set; }
        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }

        public virtual ICollection<User> Members { get; set; }
        public virtual ICollection<Event> ParticipatingEvents { get; set; }
        public virtual ICollection<Invitation> Invitations { get; set; }
    }
}
