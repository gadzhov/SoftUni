using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Football_Betting.Models
{
    public class Country
    {
        public Country()
        {
            this.Continents = new HashSet<ContinentCountries>();
        }

        [MaxLength(3)]
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ContinentCountries> Continents { get; set; }
    }
}
