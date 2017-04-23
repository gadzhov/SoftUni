using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Football_Betting.Models
{
    public class Game
    {
        public Game()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
            this.BetGame = new HashSet<BetGame>();
        }

        public int Id { get; set; }

        [Column("HomeTeam")]
        public virtual Team HomeTeam { get; set; }

        [Column("AwayTeam")]
        public virtual Team AwayTeam { get; set; }

        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public DateTime DateTime { get; set; }
        public double HomeTeamWinBetRate { get; set; }
        public double AwayTeamWinBetRate { get; set; }
        public double DrawGameBetRate { get; set; }

        [ForeignKey("Round")]
        public int RoundId { get; set; }
        public virtual Round Round { get; set; }

        [ForeignKey("Competition")]
        public int CompetitionId { get; set; }
        public virtual Competition Competition { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }
        public virtual ICollection<BetGame> BetGame { get; set; }
    }
}
