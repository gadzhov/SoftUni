using System.Collections.Generic;
using Models;

namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.BusTicketContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Data.BusTicketContext";
        }

        protected override void Seed(Data.BusTicketContext context)
        {
            var customer = new Customer()
            {
                Gender = Gender.Male,
                DateOfBirth = new DateTime(1990, 01, 23),
                FirstName = "Vladimir",
                LastName = "Ivanov",
                HomeTown = new Town() { Name = "Sofia", Country = "Bulgaria" },
                BankAccount = new BankAccount() { AccountNumber = 2313131, Balance = 2567.24m },
                Reviews = new List<Review>() { new Review()
                {
                    BusCompany = new BusCompany() {Name = "Shans94", Nationality = "Bulgaria", Rating = 9.4},
                    Content = "Exelent Trip",
                    DateAndTimeOfPublishing = DateTime.Now,
                    Grade = 10
                }
                }
            };
            context.Customers.AddOrUpdate(c => c.FirstName, customer);
            context.SaveChanges();

            var trip = new Trip()
            {
                BusCompany = new BusCompany() { Name = "Euro17", Nationality = "Bulgaria", Rating = 9.0 },
                Status = Status.Arrived,
                DepartureTime = new DateTime(2017, 03, 22, 14, 56, 23),
                ArrivalTime = new DateTime(2017, 03, 22, 17, 10, 24),
                DestinationBusStation = new BusStation() { Name = "Poduqne", Town = new Town() { Name = "Plovdiv", Country = "Bulgaria" } },
                OriginBusStation = new BusStation() { Name = "Alkatraz", Town = new Town() { Name = "Qmbol", Country = "Bulgaria" } }
            };

            context.Trips.AddOrUpdate(t => t.DepartureTime, trip);
        }
    }
}
