using System;
using System.Collections.Generic;

namespace Sales.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }
        public StoreLocation StoreLocation { get; set; }
    }
}
