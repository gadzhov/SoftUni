namespace MyCoolWebServer.Database.Models
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }

        public DateTime DateOfCreation { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public ICollection<OrderProduct> Products { get; set; } = new HashSet<OrderProduct>();
    }
}
