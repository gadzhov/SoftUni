namespace _5._Shop_Hierarchy
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using _5._Shop_Hierarchy.Models;

    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int SalesmenId { get; set; }

        public Salesmen Salesmen { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            // 6. Shop Hierarchy – Extended

            //sb.AppendLine($"{this.Name}")
            //    .AppendLine($"Orders: {this.Orders.Count}")
            //    .Append($"Reviews: {this.Reviews.Count}");

            // 7. Shop Hierarchy – Complex Query

            //foreach (var order in this.Orders)
            //{
            //    sb.AppendLine($"order {order.Id}: {order.Items.Count} items");
            //}
            //sb.Append($"reviews: {this.Reviews.Count}");

            // 8. Explicit Data Loading

            sb.AppendLine($"Customer: {this.Name}")
                .AppendLine($"Orders count: {this.Orders.Count}")
                .AppendLine($"Reviews: {this.Reviews.Count}")
                .Append($"Salesman: {this.Salesmen.Name}");

            return sb.ToString();
        }
    }
}
