using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Models;

namespace Data
{
    public class InitializeAndSeek : DropCreateDatabaseAlways<MoviesContext>
    {
        protected override void Seed(MoviesContext context)
        {
            /*
            var nova = new Director()
            {
                FirstName = "Christopher",
                LastName = "Nova"
            };
            var zemeckis = new Director()
            {
                FirstName = "Robert",
                LastName = "Zemeckis"
            };

            var movie1 = new Movie()
            {
                Title = "Interstellar",
                Genre = "Drama/Adventure/Sci-Fi",
                Rating = 8.6f,
                ReleaseYear = 2014,
                Director = nova
            };

            var movie2 = new Movie()
            {
                Title = "The Dark Knight Rises",
                Genre = "Thriller/Action",
                Rating = 8.4f,
                ReleaseYear = 2012,
                Director = nova
            };

            var movie3 = new Movie()
            {
                Title = "Contact",
                Genre = "Mystery/Drama/Sci-Fi",
                Rating = 7.6f,
                ReleaseYear = 1997,
                Director = zemeckis
            };
    
            context.Movies.Add(movie1);
            context.Movies.Add(movie2);
            context.Movies.Add(movie3);

            context.SaveChanges();

            base.Seed(context);
            */
        }
    }
}
