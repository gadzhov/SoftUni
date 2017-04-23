using System.Collections.Generic;
using System.Security.AccessControl;

namespace Models
{
    public class Town
    {
        public Town()
        {
            BusStations = new HashSet<BusStation>();
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public virtual ICollection<BusStation> BusStations { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
