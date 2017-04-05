using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Football_Betting.Models
{
    public class Player
    {
        public Player()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int SquadNumber { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public Team Team { get; set; }

        [ForeignKey("Position")]
        public string PositionId { get; set; }
        public virtual Position Position { get; set; }

        public bool IsCurrentlyInjured { get; set; }
        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}
