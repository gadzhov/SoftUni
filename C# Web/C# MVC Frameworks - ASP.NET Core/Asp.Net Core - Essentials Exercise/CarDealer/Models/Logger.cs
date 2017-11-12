namespace CarDealer.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Logger
    {
        public int Id { get; set; }

        [Required]
        public string User { get; set; }

        [Required]
        public string Operation { get; set; }

        [Required]
        [Display(Name ="Modified Table")]
        public string ModifiedTable { get; set; }

        public DateTime Time { get; set; }
    }
}
