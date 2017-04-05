using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lection.Data;
using Lection.Models;

namespace Lection
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new ChirperContext();
            context.Database.Initialize(true);

            //Joining Tables with LINQ
            var persons = from person in context.Persons
                          join town in context.Towns on person.Id equals town.Id
                          select new
                          {
                              Person = person.Name,
                              dwa = person.PlaceOfBirth,
                              dwaw = person.CurrentResidence
                          };
            //Joining Tables Extension methods
            var user = context.Persons.Join(context.Towns,
                (e => e.Id),
                (t => t.Id),
                (e, d) => new
                {
                    Employee = e.Name,
                    dwj = e.PlaceOfBirth,
                    fjekfe = d.Name
                });

            //Grouping with LINQ
            var proupedPersons = from person in context.Persons group person by person.Name;

            //Group with Extension methods
            var groupedUsers = context.Persons.GroupBy(e => e.Name);

            //Assign the fields as you would with an anonymous object:
            var currentUser = context.Persons.Select(u => new UserInfoView()
                {
                    Alias = u.Name,
                    Avatar = u.
                })
        }
        //Viewe Model
        public class UserInfoView
        {
            public string Alias { get; set; }
            public byte[] Avatar { get; set; }
        }
    }
}
