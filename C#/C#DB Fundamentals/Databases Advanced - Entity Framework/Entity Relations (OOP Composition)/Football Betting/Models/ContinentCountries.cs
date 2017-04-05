using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Football_Betting.Models
{
    public class ContinentCountries
    {
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Country")]
        public string CountryId { get; set; }
        public Country Country { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Continent")]
        public int ContinentId { get; set; }
        public Continent Continent { get; set; }
    }
}
