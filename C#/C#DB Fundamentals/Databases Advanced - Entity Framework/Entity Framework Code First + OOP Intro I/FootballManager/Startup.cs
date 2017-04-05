using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballManager.Models;

namespace FootballManager
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new FootballManagerContext();
            //context.Database.Initialize(true);
            context.Teams.Add(new Team()
            {
                Name = "Barcelona"
            });
            context.SaveChanges();
        }
    }
}
