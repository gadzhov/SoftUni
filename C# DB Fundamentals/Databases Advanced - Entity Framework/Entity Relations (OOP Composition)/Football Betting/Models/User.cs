using System.Collections.Generic;

namespace Football_Betting.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public decimal Ballance { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
