using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsShop.Models
{
    public class User
    {
        public User()
        {
            this.Friends = new HashSet<User>();
            this.ProductsBought = new HashSet<Product>();
            this.ProductsSold = new HashSet<Product>();

        }
        public int Id { get; set; }
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }
        public int? Age { get; set; }

        public virtual ICollection<User> Friends { get; set; }
        [InverseProperty("Buyer")]
        public virtual ICollection<Product> ProductsBought { get; set; }
        [InverseProperty("Seller")]
        public virtual ICollection<Product> ProductsSold { get; set; }
    }
}
