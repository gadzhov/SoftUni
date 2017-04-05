using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;
namespace Client
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new MoviesContext();

            var studio = new Studio()
            {
                Name = "Warner Bros"
            };
            var firstOrDefault = context.Movies.FirstOrDefault(m => m.Title == "Contact");
            if (firstOrDefault != null)
                firstOrDefault.Studio = studio;

            context.SaveChanges();
        }
    }
}
