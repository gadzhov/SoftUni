using System.Collections.Generic;

namespace Models
{
    public class Part
    {
        public Part()
        {
            this.Cars = new HashSet<Car>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int SuplierId { get; set; }
        public virtual Suplier Suplier { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
