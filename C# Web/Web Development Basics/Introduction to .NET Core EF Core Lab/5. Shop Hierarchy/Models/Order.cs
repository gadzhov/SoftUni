namespace _5._Shop_Hierarchy.Models
{
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public ICollection<ItemsOrders> Items { get; set; } = new List<ItemsOrders>();
    }
}
