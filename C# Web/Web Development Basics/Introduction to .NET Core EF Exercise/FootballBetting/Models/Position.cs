namespace FootballBetting.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Position
    {
        [MaxLength(2)]
        public string Id { get; set; }

        public string Description { get; set; }

        public ICollection<Player> Players { get; set; } = new HashSet<Player>();
    }
}
