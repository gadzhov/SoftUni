using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Customer
    {
       public int  Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public virtual Town HomeTown { get; set; }

        public virtual BankAccount BankAccount { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
