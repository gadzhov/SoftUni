using System.Collections.Generic;
using System.ComponentModel;

namespace Sales.Models
{
    public class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }
        public int Id { get; set; }
        //public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CreditCardNumber { get; set; }

        //[DefaultValue(20)]
        public int Age { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
