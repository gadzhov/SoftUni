using System;
using System.ComponentModel.DataAnnotations;

namespace Gringotts_Database.Models
{
    public class WizardDeposit
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(60)]
        public string LastName { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Age { get; set; }

        [StringLength(100)]
        public string MagicWandCreator { get; set; }

        [Range(1, short.MaxValue)]
        public short MagicWandSize { get; set; }

        [StringLength(20)]
        public string DepositGroup { get; set; }
        public DateTime DepositStartDate { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal DepositInterest { get; set; }
        public double DepositCharge { get; set; }
        public DateTime DepositExpirationDate { get; set; }
        public bool IsDepositExpired { get; set; }
    }
}
