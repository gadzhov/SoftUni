namespace Problem_3.Wild_farm.Models
{
    abstract class Food
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; set; }
    }
}
