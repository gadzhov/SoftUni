using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using BookShopSystem.Data;
using BookShopSystem.Models;
using EntityFramework.Extensions;

namespace BookShopSystem
{
    public class BookShopMain
    {
        static void Main()
        {
            var context = new BookShopContext();
            //context.Database.Initialize(true);

            //BookTitlesByAgeRestriction(context);
            //GoldenBooks(context);
            //BooksByPrice(context);
            //NotReleasedBooks(context);
            //BookTitlesByCategory(context);
            //BooksReleasedBeforeDate(context);
            //AuthorsSearch(context);
            //BookSearch(context);
            //BookTitlesSearch(context);
            //CountBooks(context);
            //TotalBookCopies(context);
            //FindProfit(context);
            // MostRecentBooks(context);
            //IncreaseBookCopies(context);
            //RemoveBooks(context);
            //StoredProcedure(context);
        }
        //01.
        private static void BookTitlesByAgeRestriction(BookShopContext context)
        {
            var restriction = Console.ReadLine().ToLower();
            var books = context.Books
                .Where(b => b.AgeRestriction.ToString().ToLower() == restriction)
                .Select(b => b.Title)
                .ToList();
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        //02.
        private static void GoldenBooks(BookShopContext context)
        {
            var goldenEditionBooks =
                context.Books.Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                    .OrderBy(b => b.Id)
                    .Select(b => b.Title)
                    .ToList();
            goldenEditionBooks.ForEach(Console.WriteLine);
        }

        //03.

        private static void BooksByPrice(BookShopContext context)
        {
            context.Books
                .Where(b => b.Price < 5 || b.Price > 40)
                .OrderBy(b => b.Id)
                .Select(b => new { b.Title, b.Price })
                .ToList()
                .ForEach(b => Console.WriteLine($"{b.Title} - {b.Price}"));
        }

        //04.
        private static void NotReleasedBooks(BookShopContext context)
        {
            var givenYear = int.Parse(Console.ReadLine());
            context.Books
                .Where(b => b.ReleaseDate.Value.Year != givenYear)
                .OrderBy(b => b.Id)
                .Select(b => b.Title)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        //05.
        private static void BookTitlesByCategory(BookShopContext context)
        {
            var categoriesList = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower());
            context.Books
                .Where(b => b.Categories.Any(c => categoriesList.Contains(c.Name.ToLower())))
                .Select(b => b.Title)
                .ToList()
            .ForEach(Console.WriteLine);
        }

        //06.
        private static void BooksReleasedBeforeDate(BookShopContext context)
        {
            var givenDate = DateTime.Parse(Console.ReadLine());
            context.Books.Where(b => b.ReleaseDate < givenDate)
                .Select(b => new { b.Title, b.EditionType, b.Price })
                .ToList()
                .ForEach(b => Console.WriteLine($"{b.Title} - {b.EditionType} - {b.Price}"));
        }

        //07.
        private static void AuthorsSearch(BookShopContext context)
        {
            var givenString = Console.ReadLine();
            context.Authors.Where(a => a.FirstName.Substring(a.FirstName.Length - givenString.Length) == givenString).Select(a => new { a.FirstName, a.LastName }).ToList().ForEach(a => Console.WriteLine($"{a.FirstName} {a.LastName}"));
        }

        //08.
        private static void BookSearch(BookShopContext context)
        {
            var givenString = Console.ReadLine().ToLower();
            context.Books
                .Where(b => b.Title.ToLower()
                .Contains(givenString))
                .Select(b => b.Title)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        //09.
        private static void BookTitlesSearch(BookShopContext context)
        {
            var givenString = Console.ReadLine().ToLower();
            context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(givenString))
                .OrderBy(b => b.Id)
                .Select(b => b.Title)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        //10.
        private static void CountBooks(BookShopContext context)
        {
            var givenNumber = int.Parse(Console.ReadLine());
            var count = context.Books
                .Where(b => b.Title.Length > givenNumber)
                .Select(b => b.Title)
                .Count();
            Console.WriteLine(count);
        }

        //11.
        private static void TotalBookCopies(BookShopContext context)
        {
            context.Books
                .GroupBy(b => b.Author)
                .Select(b => new { Author = b.Key.FirstName + " " + b.Key.LastName, Copies = b.Sum(c => c.Copies) })
                .OrderByDescending(c => c.Copies)
                .ToList()
                .ForEach(b => Console.WriteLine($"{b.Author} - {b.Copies}"));
        }

        //12.
        private static void FindProfit(BookShopContext context)
        {
            context.Categories
                .GroupBy(c => new
                {
                    CategoryName = c.Name,
                    CategoryProfit = c.Books.Sum(b => b.Price * b.Copies)
                })
                .OrderByDescending(c => c.Key.CategoryProfit)
                .ThenBy(c => c.Key.CategoryName)
                .ToList()
                .ForEach(c => Console.WriteLine($"{c.Key.CategoryName} {c.Key.CategoryProfit}"));
        }

        //13.
        private static void MostRecentBooks(BookShopContext context)
        {
            var categoriesOfRecentBooks = context.Categories
                .Where(c => c.Books.Count > 35)
                .Select(c => new
                {
                    c.Name,
                    c.Books.Count,
                    RecentBooks = c.Books
                    .OrderByDescending(b => b.ReleaseDate)
                    .ThenBy(b => b.Title)
                    .Take(3)
                    .Select(b => new
                    {
                        b.Title,
                        b.ReleaseDate
                    })
                })
                .ToList();

            foreach (var c in categoriesOfRecentBooks.OrderByDescending(c => c.Count))
            {
                Console.WriteLine($"--{c.Name}: {c.Count} books");
                foreach (var b in c.RecentBooks)
                {
                    Console.WriteLine($"{b.Title} ({b.ReleaseDate.Value.Year})");
                }
            }
        }

        //14.
        private static void IncreaseBookCopies(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate > new DateTime(2013, 06, 06));
            Console.WriteLine(books.Count() * 44);
            //Use EF Extended
            books.Update(b => new Book
            {
                Copies = b.Copies + 44
            });
            context.SaveChanges();
        }

        //15.
        private static void RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200);
            Console.WriteLine($"{books.Count()} books were deleted");
            books.Delete();
            context.SaveChanges();
        }

        //16.
        private static void StoredProcedure(BookShopContext context)
        {
            var givenNames = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var firstName = new SqlParameter("@firstName", SqlDbType.VarChar);
            var lastName = new SqlParameter("@lastName", SqlDbType.VarChar);
            firstName.Value = givenNames[0];
            lastName.Value = givenNames[1];
            var booksCount = context.Database.SqlQuery<int>("prc_TotalBooks @firstName, @lastName", firstName, lastName).Single();
            Console.WriteLine($"{firstName.Value} {lastName.Value} has written {booksCount} books");
        }
    }

}
