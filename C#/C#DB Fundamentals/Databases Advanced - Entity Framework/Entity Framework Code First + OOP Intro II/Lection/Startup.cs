using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new MovieContext();
            context.Database.Initialize(true);

            foreach (var m in context.Movies.ToList())
            {
                Console.WriteLine(m.Title);
            }
        }
    }
}
