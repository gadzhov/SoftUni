using System.Collections.Generic;

namespace Football_Betting.Models
{
    public class Town
    {
        public Town()
        {
            this.Teams = new HashSet<Team>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
