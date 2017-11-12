using System.ComponentModel.DataAnnotations;

namespace CarDealer.Models.BindingModels
{
    public class SaleBindingModel
    {
        [Required]
        public string Customer { get; set; }

        [Required]
        [Display(Name = "Car")]
        public int CarId { get; set; }

        [Required]
        public double Discount { get; set; }
    }
}
