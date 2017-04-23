using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Football_Betting.Models
{
    public class Position
    {
        public Position()
        {
            this.Players = new HashSet<Player>();
        }
        [MaxLength(2)]
        public string Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
