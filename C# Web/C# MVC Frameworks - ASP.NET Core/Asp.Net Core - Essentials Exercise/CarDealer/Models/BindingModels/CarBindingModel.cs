using System.ComponentModel.DataAnnotations;

namespace CarDealer.Models.BindingModels
{
    public class CarBindingModel
    {
        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public long TravelledDistance { get; set; }
    }
}
