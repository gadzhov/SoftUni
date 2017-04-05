namespace Local_Store.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DistributorName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Weight { get; set; }
        public int Qiantiy { get; set; }
    }
}
