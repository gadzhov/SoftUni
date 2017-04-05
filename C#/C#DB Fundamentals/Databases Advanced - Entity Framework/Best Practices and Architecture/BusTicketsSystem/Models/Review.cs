using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }
        [Range(1, 10)]
        public double Grade { get; set; }
        public virtual BusCompany BusCompany { get; set; }
        public virtual Customer Customer { get; set; }
        public DateTime DateAndTimeOfPublishing { get; set; }
    }
}
