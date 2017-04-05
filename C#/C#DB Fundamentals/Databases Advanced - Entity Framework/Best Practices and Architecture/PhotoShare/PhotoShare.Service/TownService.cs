using System;
using System.Linq;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Service
{
    public class TownService
    {
        public virtual void AddTown(string townName, string countryName)
        {
            using (var context = new PhotoShareContext())
            {
                var town = new Town
                {
                    Name = townName,
                    Country = countryName
                };

                context.Towns.Add(town);
                context.SaveChanges();
            }
        }

        public virtual bool IsTownExisting(string townName)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Towns.Any(t => t.Name == townName);
            }
        }

        public Town GetByTownName(string townName)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Towns.SingleOrDefault(t => t.Name == townName);
            }
        }
    }
}
