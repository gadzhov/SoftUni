using System.Collections.Generic;

namespace FootballManager.Models
{
    public class League
    {
        public League()
        {
            this.Teams = new HashSet<Team>();
        }
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
