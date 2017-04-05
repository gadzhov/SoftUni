using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photographers.Data;
using Photographers.Models;

namespace Photographers
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new PhotographersContext();
            //05. Insert Sample Data

            /*
            context.Database.Initialize(true);
            var photographers = new List<Photographer>()
            {
                new Photographer() { BirthDate = new DateTime(1991, 10, 18), Email = "georgi@abv.bg", Password = "qwert12345@", RegisterDate = new DateTime(2012, 05, 25), UserName = "gogo45" },
                new Photographer() { BirthDate = new DateTime(1992, 01, 18), Email = "ivan@abv.bg", Password = "qwert12345@", RegisterDate = new DateTime(2014, 06, 21), UserName = "vankata" },
                new Photographer() { BirthDate = new DateTime(1997, 1, 11), Email = "galq@abv.bg", Password = "qwert12345@", RegisterDate = new DateTime(2016, 12, 25), UserName = "galka-malka" }
            };
            foreach (var photographer in photographers)
            {
                context.Photographers.Add(photographer);
            }
            context.SaveChanges();
            */


        }
    }
}
