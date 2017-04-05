using System.Collections.Generic;

namespace Models
{
    public class BusCompany
    {
        public BusCompany()
        {
            Reviews = new HashSet<Review>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public double Rating { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
