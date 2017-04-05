using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Football_Betting.Models
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("CompetitionType")]
        public int CompetitionTypeId { get; set; }
        public CompetitionType CompetitionType { get; set; }
    }
}
