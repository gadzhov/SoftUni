using System.Collections.Generic;
using System.Data.Entity.Migrations;
using PhotoShare.Models;

namespace PhotoShare.Data.Migrations
{
    internal class Configuration : DbMigrationsConfiguration<PhotoShareContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhotoShareContext context)
        {
            context.Albums.AddOrUpdate(a => a.Name , new Album()
            {
                IsPublic = true,
                Name = "Nature",
                Pictures =
                    new List<Picture>()
                    {
                        new Picture() {Caption = "Bulgaria", Path = "../../Images/01.jpg", Title = "Rila"}
                    },
                Tags = new List<Tag>() {new Tag() {Name = "#nature"}, new Tag() {Name = "#beautiful"}},
                AlbumRoles = new List<AlbumRole>()
                {
                    new AlbumRole()
                    {
                        Role = Role.Owner,
                        User = new User()
                        {
                            Email = "dwad@abv.bg",
                            Age = 24,
                            FirstName = "Gergana",
                            LastName = "Todorova",
                            Password = "dwad12312dwW@",
                            Username = "gericima"
                        }
                    }
                }
            });
            context.Albums.AddOrUpdate(a => a.Name, new Album()
            {
                IsPublic = true,
                Name = "Sea",
                Pictures =
                    new List<Picture>()
                    {
                        new Picture() {Caption = "Bulgaria", Path = "../../Images/02.jpg", Title = "Black Sea"}
                    },
                Tags = new List<Tag>() { new Tag() { Name = "#nature" }, new Tag() { Name = "#beautiful" }, new Tag() {Name = "#blacksea"} },
                AlbumRoles = new List<AlbumRole>()
                {
                    new AlbumRole()
                    {
                        Role = Role.Owner,
                        User = new User()
                        {
                            Email = "dwad2123@abv.bg",
                            Age = 23,
                            FirstName = "Martina",
                            LastName = "Andonova",
                            Password = "dw23ad1!2312dwW@",
                            Username = "Marti94",
                            BornTown = new Town() {Name = "Sofia", Country = "Bulgaria", },
                            CurrentTown = new Town() {Name = "Burgas", Country = "Bulgaria"},
                        }
                    }
                }
            });
        }
    }
}
