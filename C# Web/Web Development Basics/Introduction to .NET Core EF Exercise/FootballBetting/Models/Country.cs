namespace FootballBetting.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        [MaxLength(3)]
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<CountriesContinets> Continetses { get; set; } = new HashSet<CountriesContinets>();
    }
}
