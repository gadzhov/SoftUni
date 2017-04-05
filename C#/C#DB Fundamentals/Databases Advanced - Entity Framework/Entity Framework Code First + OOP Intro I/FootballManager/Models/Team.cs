using System.Collections.Generic;

namespace FootballManager.Models
{
     public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
            this.Leagues = new HashSet<League>();
        }
        public virtual int TeamId { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<League> Leagues { get; set; }
    }
}
