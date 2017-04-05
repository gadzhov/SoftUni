using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lection.Models;

namespace Lection
{
    public class InitializeAndSeed : DropCreateDatabaseAlways<MovieContext>
    {
        protected override void Seed(MovieContext context)
        {
            //var defaultMovies = new List<Movie>
            //{
            //    new Movie() {Title = "The Flash", ReleaseYear = 2014, Rate = 9.1f, Duration = 40},
            //    new Movie() {Title = "Arrow", ReleaseYear = 2012, Rate = 9.0f, Duration = 45}
            //};
            //foreach (var movie in defaultMovies)
            //{
            //    context.Movies.Add(movie);
            //}
            //base.Seed(context);
        }
    }
}
