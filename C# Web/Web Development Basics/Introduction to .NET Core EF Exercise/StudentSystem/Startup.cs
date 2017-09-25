namespace StudentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Student_System.Data;
    using Student_System.Models;
    using Student_System.Models.Enums;

    public class Startup
    {
        public static void Main()
        {
            using (StudentContext context = new StudentContext())
            {
                context.Database.Migrate();

                // SeedData(context);
                // ListAllStudentsWithHomework(context);
                // ListAllCoursesWithResources(context);
                // ListCoursesWithMoreThanFiceResources(context);
                // ListAllCoursesActiveOnGivenDate(context);
                // ListOfStudentsCourses(context);
                // SeedLicenses(context);
                // ListAllCoursesWithLicense(context);
            }
        }

        private static void SeedData(StudentContext context)
        {
            DateTime currentDateTime = DateTime.Now;
            Random rnd = new Random();
            // Courses
            Console.WriteLine($"Seeding Courses...");
            for (int i = 0; i < 30; i++)
            {
                Course course = new Course()
                {
                    Description = $"Description {i}",
                    EndDate = currentDateTime.AddDays(20),
                    Name = $"Course {i}",
                    Price = i * 10,
                    StartDate = currentDateTime.AddDays(-30)
                };

                context.Courses.Add(course);
            }
            context.SaveChanges();

            // Resource
            Console.WriteLine($"Seeding Resource...");
            List<Course> courses = context
                .Courses
                .ToList();
            for (int i = 0; i < 90; i++)
            {
                Resource resource = new Resource()
                {
                    Name = $"Resource {i}",
                    TypeOfResource = (TypeOfResource)rnd.Next(0, 4),
                    Url = $"www.{i}.com",
                    Course = courses[rnd.Next(0, courses.Count)]
                };
                context.Resourceses.Add(resource);
            }
            context.SaveChanges();

            // Students
            for (int i = 0; i < 30; i++)
            {
                Student student = new Student()
                {
                    Name = $"Student{i}",
                    BirthDate = currentDateTime.AddYears(-27),
                    Phonenumber = $"08820000{i}",
                    RegistrationTime = currentDateTime.AddDays(-30 - i)
                };

                context.Students.Add(student);
            }

            context.SaveChanges();

            // Homeworks
            Console.WriteLine($"Seeding Homeworks...");
            List<Student> students = context.Students.ToList();
            for (int i = 0; i < 90; i++)
            {
                Homework homework = new Homework()
                {
                    Content = $"Content {i}",
                    ContentType = (ContentType)rnd.Next(0, 3),
                    SubmissionDate = currentDateTime.AddMinutes(-20 - i),
                    Course = courses[rnd.Next(0, courses.Count)],
                    Student = students[rnd.Next(0, students.Count)]
                };

                context.Homeworks.Add(homework);
            }

            context.SaveChanges();

            // StudentCourses
            Console.WriteLine($"Seeding StudentResources...");
            for (int i = 0; i < courses.Count; i++)
            {
                courses[i].Students.Add(new StudentCourses()
                {
                    Student = students[rnd.Next(0, students.Count)]
                });

            }

            context.SaveChanges();
        }

        private static void ListAllStudentsWithHomework(StudentContext context)
        {
            var students = context
                .Students
                .Select(s => new
                {
                    s.Name,
                    Homework = s.Homeworks.Select(h => new
                    {
                        h.Content,
                        h.ContentType
                    })
                })
                .ToList();

            foreach (var student in students)
            {
                Console.WriteLine(student.Name);
                foreach (var hw in student.Homework)
                {
                    Console.WriteLine($"---{hw.Content} [{hw.ContentType}]");
                }
            }
        }

        private static void ListAllCoursesWithResources(StudentContext context)
        {
            var cources = context
                .Courses
                .OrderBy(c => c.StartDate)
                .ThenByDescending(c => c.EndDate)
                .Select(c => new
                {
                    c.Name,
                    c.Description,
                    Resource = c.Resourceses
                });

            foreach (var cource in cources)
            {
                Console.WriteLine($"{cource.Name} - {cource.Description}");
                foreach (var resource in cource.Resource)
                {
                    Console.WriteLine($"--- {resource.Name} - {resource.TypeOfResource} - {resource.Url}");
                }
            }
        }

        private static void ListCoursesWithMoreThanFiceResources(StudentContext context)
        {
            context
                .Courses
                .Where(c => c.Resourceses.Count >= 5)
                .OrderByDescending(c => c.Resourceses.Count)
                .ThenByDescending(c => c.StartDate)
                .Select(c => new
                {
                    c.Name,
                    Count = c.Resourceses.Count
                })
                .ToList()
                .ForEach(c => Console.WriteLine($"{c.Name} - {c.Count}"));
        }

        private static void ListAllCoursesActiveOnGivenDate(StudentContext context)
        {
            var courses = context
                .Courses
                .Where(c => c.EndDate < new DateTime(2017, 12, 01))
                .Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    CourseDuration = c.EndDate.Subtract(c.StartDate),
                    EnrolledStudents = c.Students.Count
                })
                .OrderByDescending(c => c.EnrolledStudents)
                .ThenByDescending(c => c.CourseDuration)
                .ToList();


            Console.WriteLine(string.Join(", ", courses));
        }

        private static void ListOfStudentsCourses(StudentContext context)
        {
            var students = context
                .Students
                .Where(s => s.Courseses.Count > 0)
                .Select(s => new
                {
                    s.Name,
                    NumberOfCourses = s.Courseses.Count,
                    TotalPrice = s.Courseses.Sum(c => c.Course.Price),
                    AveragePrice = s.Courseses.Average(c => c.Course.Price)
                })
                .OrderByDescending(c => c.TotalPrice)
                .ThenByDescending(c => c.NumberOfCourses)
                .ThenBy(c => c.Name)
                .ToList();

            Console.WriteLine(string.Join(", ", students));
        }

        private static void SeedLicenses(StudentContext context)
        {
            Console.WriteLine($"Seeding Linceses...");
            List<Resource> resources = context
                .Resourceses
                .ToList();
            Random rnd = new Random();

            for (int i = 0; i < 30; i++)
            {
                License license = new License()
                {
                    Name = $"License {i}",
                    Resource = resources[rnd.Next(0, resources.Count)]
                };

                context.Licenses.Add(license);
            }

            context.SaveChanges();
        }

        private static void ListAllCoursesWithLicense(StudentContext context)
        {
            var courses = context
                .Courses
                .Select(c => new
                {
                    CourseName = c.Name,
                    ResourceName = c.Resourceses.Select(r => r.Name),
                    LicenseName = c.Resourceses.Where(r => r.Licenses.Count > 0).Select(r => r.Licenses.Select(l => l.Name))
                })
                .ToList();

            foreach (var course in courses)
            {
                Console.WriteLine(course.CourseName);
                foreach (var license in course.LicenseName)
                {
                    foreach (var l in license)
                    {
                        Console.WriteLine($"--[License] {l}");
                    }
                }
                foreach (var resouce in course.ResourceName)
                {
                    Console.WriteLine($"---[Resource] {resouce}");
                }
            }
        }
    }
}