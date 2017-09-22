namespace _5._Shop_Hierarchy.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Salesmen
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Customer> Customers { get; set; } = new List<Customer>();

        public override string ToString()
        {
            return $"{this.Name} - {this.Customers.Count} customers";
        }
    }
}