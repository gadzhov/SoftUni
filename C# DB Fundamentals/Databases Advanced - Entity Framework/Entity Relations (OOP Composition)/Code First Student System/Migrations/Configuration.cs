using System.Collections.Generic;
using Code_First_Student_System.Models;

namespace Code_First_Student_System.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Code_First_Student_System.Data.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "Code_First_Student_System.Data.StudentContext";
        }

        protected override void Seed(Data.StudentContext context)
        {
            // 02. Seed some Data in the Database

            context.Courses.AddOrUpdate(course => course.Name, new Course()
            {
                Name = "C#",
                EndDate = DateTime.Now,
                StartDate = new DateTime(2017,01,01),
                Description = "C# Fundamentals",
                Price = 260,
                Students = new List<Student>()
                    {
                        new Student()
                        {
                            Name = "Pesho",
                            RegisteredOn = new DateTime(2012,10,12),
                            BirthDay = new DateTime(1990,01,23),
                            PhoneNumber = 2313131,
                           Homeworks = new List<Homework>()
                           {
                               new Homework()
                               {
                                   Content = "dwada",
                                   ContentType = "pdf",
                                   SubmissionDate = DateTime.Now
                               }
                           }
                        }
                    },
                Resources = new List<Resource>()
                    {
                        new Resource()
                        {
                            Name = "dwada",
                            ResourceType = "Document",
                            Url = "https://www.softuni.bg"
                        }
                    }
            }
            );
        }
    }
}
