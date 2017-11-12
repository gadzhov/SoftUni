namespace CarDealer.Models.ViewModels
{
    using System.Collections.Generic;

    public class CarPartsViewModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public IEnumerable<PartViewModel> Parts { get; set; }
    }
}
