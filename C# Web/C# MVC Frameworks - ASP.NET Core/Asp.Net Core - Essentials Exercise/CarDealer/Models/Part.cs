using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Models
{
    public class Part
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int? Quantity { get; set; }

        [Display(Name="Supplier")]
        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        public ICollection<PartCars> PartCars { get; set; } = new HashSet<PartCars>();
    }
}
