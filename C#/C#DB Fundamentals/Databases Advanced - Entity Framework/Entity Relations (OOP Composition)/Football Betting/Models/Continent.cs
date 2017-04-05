using System.Collections.Generic;

namespace Football_Betting.Models
{
    public class Continent
    {
        public Continent()
        {
            this.Countries = new HashSet<ContinentCountries>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ContinentCountries> Countries { get; set; }
    }
}
