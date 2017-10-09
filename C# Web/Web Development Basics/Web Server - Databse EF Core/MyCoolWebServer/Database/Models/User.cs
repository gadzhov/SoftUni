namespace MyCoolWebServer.Database.Models
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime DateOfRegistration { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
