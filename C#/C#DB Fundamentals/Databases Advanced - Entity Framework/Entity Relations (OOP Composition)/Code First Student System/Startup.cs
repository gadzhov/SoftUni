using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Linq;
using Code_First_Student_System.Data;
using Code_First_Student_System.Models;

namespace Code_First_Student_System
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new StudentContext();
            // 03. Working with the Database

            // 03-01. Lists all students and their homework submissions. Print only their names and for each homework - content and content-type.
            var students = context.Students.ToList();
            foreach (var student in students)
            {
                Console.WriteLine($"Student Name: {student.Name}");
                foreach (var studentHomework in student.Homeworks)
                {
                    Console.WriteLine($"Content: {studentHomework.Content}, Content-Type: {studentHomework.ContentType}");
                }
            }

            // 03-02. List all courses with their corresponding resources. Print the course name and description and everything for each resource. Order the courses by start date (ascending), then by end date (descending).
            var courses = context.Courses.OrderBy(c => c.StartDate).ThenByDescending(c => c.EndDate).ToList();
            foreach (var course in courses)
            {
                Console.WriteLine($"Course Name: {course.Name}, Course Description: {course.Description}");
                foreach (var courseResource in course.Resources)
                {
                    Console.WriteLine($"Resource ID: {courseResource.Id}, Course Name: {courseResource.Name}, Resource Type: {courseResource.ResourceType}, Resource URL: {courseResource.Url} Resource Course ID: {courseResource.Course.Id}");
                }
            }

            // 03-03. List all courses with more than 5 resources.Order them by resources count(descending), then by start date (descending).Print only the course name and the resource count.
            var coursesMore =
                context.Courses.Where(c => c.Resources.Count > 5)
                    .OrderByDescending(c => c.Resources.Count)
                    .ThenByDescending(c => c.StartDate)
                    .ToList();
            foreach (var course in coursesMore)
            {
                Console.WriteLine($"Course Name: {course.Name}, Resource Count: {course.Resources.Count}");
            }

            /* 03-04.	*List all courses which were active on a given date (choose the date depending on the data seeded to ensure there are results), and for each course count the number of students enrolled. 
            Print the course name, start and end date, course duration (difference between end and start date in days) and number of students enrolled.Order the results by the number of students enrolled(in descending order), then by duration(descending).
            */
            Console.Write("Enter date: ");
            var givenDate = DateTime.Parse(Console.ReadLine());

            var coursesActive = context.Courses.Where(c => c.StartDate <= givenDate && c.EndDate >= givenDate).OrderByDescending(c => c.Students.Count).ToList();
            foreach (var course in coursesActive)
            {
                Console.WriteLine($"Course Name: {course.Name}, Start Date: {course.StartDate}, End Date: {course.EndDate}, Duration {(course.EndDate - course.StartDate).Days}");
            }

            /* 03-05.	For each student, get the number of courses he/she has enrolled in, the total price of these courses and the average price per course for the student.
            Print the student name, number of courses, total price and average price. Order the results by total price (descending), then by number of courses      (descending)     and then by the student's name (ascending).
            */

            var students1 =
                context.Students.OrderByDescending(s => s.Courses.Max(c => c.Price))
                    .ThenByDescending(s => s.Courses.Count)
                    .ThenBy(s => s.Name)
                    .ToList();
            foreach (var student in students1)
            {
                Console.WriteLine($"Student Name: {student.Name}, Courses Count: {student.Courses.Count}, Total Price: {student.Courses.Sum(c => c.Price)}, Average Price: {student.Courses.Average(c => c.Price)}");
            }
        }
    }
}
