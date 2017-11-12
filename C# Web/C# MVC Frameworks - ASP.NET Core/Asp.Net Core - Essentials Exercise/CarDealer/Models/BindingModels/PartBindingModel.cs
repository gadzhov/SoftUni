using System.ComponentModel.DataAnnotations;

namespace CarDealer.Models.BindingModels
{
    public class PartBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int? Quantity { get; set; }

        public string Supplier { get; set; }
    }
}
