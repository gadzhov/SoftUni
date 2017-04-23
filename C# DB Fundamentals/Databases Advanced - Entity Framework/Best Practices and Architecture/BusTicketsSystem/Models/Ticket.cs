using System.Security.Cryptography;

namespace Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Seat { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
