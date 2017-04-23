using System;
using System.Collections.Generic;
using Photographers.Models;

namespace Photographers.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Photographers.Data.PhotographersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Photographers.Data.PhotographersContext";
        }

        protected override void Seed(Photographers.Data.PhotographersContext context)
        {
            // 06. Add some seeds

            context.Photographers.AddOrUpdate(p => p.UserName, new Photographer()
            {
                BirthDate = new DateTime(2000, 06, 12), UserName = "Mariq", Email = "Mima-otvarchkata@gmail.com", RegisterDate = DateTime.Now, Password = "2313123", Albums = new List<Album>()
                {
                    new Album()
                    {
                        Name = "Forest", BackgroundColor = "black",
                        IsPublic = true,
                        Pictures = new List<Picture>()
                        {
                            new Picture()
                            {
                                Caption = "dwada",
                                PicturePath = "../../images/01.jpg",
                                Title = "dwada"
                            }, 
                            new Picture()
                            {
                                Caption = "dwada",
                                PicturePath = "../../imgaes/02.jpg",
                                Title = "dwada"
                            }
                        }
                    }
                }
            });
        }
    }
}
