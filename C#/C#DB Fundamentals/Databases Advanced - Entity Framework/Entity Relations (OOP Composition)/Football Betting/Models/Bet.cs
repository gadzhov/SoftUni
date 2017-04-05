using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Football_Betting.Models
{
    public class Bet
    {
        public Bet()
        {
            this.BetGame = new HashSet<BetGame>();
        }
        public int Id { get; set; }
        public decimal BetMoney { get; set; }
        public DateTime DateTimeOfBet { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<BetGame> BetGame { get; set; }
    }
}
