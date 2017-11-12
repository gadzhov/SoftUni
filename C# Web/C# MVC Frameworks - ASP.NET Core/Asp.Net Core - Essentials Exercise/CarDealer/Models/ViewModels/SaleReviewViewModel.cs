using System.ComponentModel.DataAnnotations;

namespace CarDealer.Models.ViewModels
{
    public class SaleReviewViewModel
    {
        private double discount;

        public string Customer { get; set; }

        public string Car { get; set; }

        public int CarId { get; set; }

        public double Discount
        {
            get => this.discount * 100;
            set => this.discount = value;
        }

        [Display(Name = "Car Price")]
        public decimal CarPrice { get; set; }

        [Display(Name = "Final Car Price")]
        public decimal FinalCarPrice => this.CarPrice * (decimal)this.Discount / 100;
    }
}
