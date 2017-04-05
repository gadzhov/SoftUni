using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gringotts_Database.Models;

namespace Gringotts_Database
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new GringottsContext();
            context.Database.Initialize(true);
            WizardDeposit dumbledore = new WizardDeposit()
            {
                FirstName = "Albus",
                LastName = "Dumbledore",
                Age = 150,
                MagicWandCreator = "Antioch Pavarell",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2016, 10, 20),
                DepositExpirationDate = new DateTime(2020, 10, 20),
                DepositAmount = 20000.24m,
                DepositCharge = 0.2,
                IsDepositExpired = false
            };
            context.WizardDeposits.Add(dumbledore);
            context.SaveChanges();
        }
    }
}
