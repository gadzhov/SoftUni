using System.Collections.Generic;

namespace Sales.Models
{
    public class StoreLocation
    {
        public StoreLocation()
        {
            Sales = new HashSet<Sale>();
        }
        public int Id { get; set; }
        public string LocationName { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
