using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Football_Betting.Models
{
    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Logo { get; set; }

        [MaxLength(3)]
        public string Initials { get; set; }

        public virtual Color PrimaryColor { get; set; }
        public virtual Color SecondaryColor { get; set; }
        public virtual Town Town { get; set; }
        public decimal Budget { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        [InverseProperty("HomeTeam")]
        public virtual ICollection<Game> HomeTeams { get; set; }

        [InverseProperty("AwayTeam")]
        public virtual ICollection<Game> AwayTeams { get; set; }
    }
}
