namespace BookShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
        }

        public static int RemoveBooks(BookShopContext context)
        {
            //Remove all books, which have less than 4200 copies.Return an int -the number of books that were deleted from the database.

            var categoriesToRemove = context.BooksCategories
                .Where(x => x.Book.Copies < 4200)
                .ToList();

            context.RemoveRange(categoriesToRemove);
            context.SaveChanges();

            var booksToRemove = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            context.RemoveRange(booksToRemove);

            context.SaveChanges();

            return booksToRemove.Count();
        }
        public static void IncreasePrices(BookShopContext context)
        {
            //Increase the prices of all books released before 2010 by 5.

            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();

        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            //Get the most recent books by categories. The categories should be ordered by name alphabetically. Only take the top 3 most recent books from each category - ordered by release date (descending). Select and print the category name, and for each book – its title and release year.

            var categories = context.Categories
                .Select(x => new
                {
                    Name = x.Name,
                    Books = x.CategoryBooks
                    .OrderByDescending(x => x.Book.ReleaseDate)
                    .Take(3)
                    .Select(x => new
                    {
                        x.Book.Title,
                        ReleaseDate = x.Book.ReleaseDate.Value.Year
                    })
                    .ToList()
                })
                .OrderBy(x=>x.Name)
                .ToList();

            var sb = new StringBuilder();
            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate})");
                }
            }

            return sb.ToString().Trim();
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            //Return the total profit of all books by category. Profit for a book can be calculated by multiplying its number of copies by the price per single book. Order the results by descending by total profit for category and ascending by category name.

            var totalProfit = context.Categories
                .Select(x => new
                {
                    Name = x.Name,
                    Profit = x.CategoryBooks.Select(x => x.Book.Price * x.Book.Copies).Sum()
                })
                .ToList()
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.Name)
                .Select(x=>$"{x.Name} ${x.Profit:F2}")
                .ToList();

               

            return String.Join(Environment.NewLine, totalProfit);
        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            //Return the total number of book copies for each author. Order the results descending by total book copies.
            //Return all results in a single string, each on a new line.

            var numberOfBookCopies = context.Authors
                .OrderByDescending(x => x.Books.Select(b=>b.Copies).Sum())
                .Select(x =>$"{x.FirstName} {x.LastName} - { x.Books.Select(x => x.Copies).Sum()}" )
                .ToList();

            return String.Join(Environment.NewLine, numberOfBookCopies);

        }
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            //Return the number of books, which have a title longer than the number given as an input.

            var lengthSum = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Select(x=>x.Title.Length)
                .ToList()
                .Count();

            return lengthSum;
        }
        public static string GetBooksByAuthor(BookShopContext context, string input) {
            //Return all titles of books and their authors’ names for books, which are written by authors whose last names start with the given string.
            //Return a single string with each title on a new row.Ignore casing.Order by book id ascending.


            var books = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .Select(x => $"{x.Title} ({x.Author.FirstName} {x.Author.LastName})")
                .ToList();

            return String.Join(Environment.NewLine, books);

        }
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            //Return the titles of book, which contain a given string.Ignore casing.
            //Return all titles in a single string, each on a new row, ordered alphabetically.
            var books = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(x => x.Title)
                .Select(x => x.Title)
                .ToList();

            return String.Join(Environment.NewLine, books);
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            //Return the full names of authors, whose first name ends with a given string.
            //Return all names in a single string, each on a new row, ordered alphabetically.

            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => x.FirstName + " " + x.LastName)
                .OrderBy(x => x)
                .ToList();

            return String.Join(Environment.NewLine, authors);

        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            //Return the title, edition type and price of all books that are released before a given date. The date will be a string in format dd-MM-yyyy.
            //Return all of the rows in a single string, ordered by release date descending.

            var dateSplitted = date.Split("-", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var dateTime = new DateTime(dateSplitted[2], dateSplitted[1], dateSplitted[0]);

            var books = context.Books
                .Where(x => x.ReleaseDate < dateTime)
                .OrderByDescending(x => x.ReleaseDate)
                .ToList();

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().Trim();

        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            //Return in a single string the titles of books by a given list of categories.The list of categories will be given in a single line separated with one or more spaces.Ignore casing. Order by title alphabetically.

            HashSet<string> categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToHashSet();

            var books = new HashSet<Book>();
            
            foreach (var category in categories)
            {
                var tempBooks = context.Books
                    .Where(x => x.BookCategories.Any(c => c.Category.Name.ToLower() == category.ToLower()))
                    .ToList();

                books.UnionWith(tempBooks);
            }

            var sb = new StringBuilder();

            foreach (var book in books.OrderBy(x=>x.Title))
            {
                sb.AppendLine(book.Title);
            }
            return sb.ToString().Trim();

        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year) {
            //Return in a single string all titles of books that are NOT released on a given year. Order them by book id ascending.
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x=>x.Title)
                .ToList();

            return String.Join(Environment.NewLine, books);
        }
        public static string GetBooksByPrice(BookShopContext context) {
            //Return in a single string all titles and prices of books with price higher than 40, each on a new row in the format given below. Order them by price descending.

            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    Title = x.Title,
                    Price = x.Price
                })
                .OrderByDescending(x=>x.Price)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().Trim();
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            //Return in a single string titles of the golden edition books that have less than 5000 copies, each on a new line. Order them by book id ascending.
            //Call the GetGoldenBooks(BookShopContext context) method in your Main() and print the returned string to the console.

            var books = context.Books
                .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x=>x.Title)
                .ToList();

            
            return String.Join(Environment.NewLine, books);
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            //Return in a single string all book titles, each on a new line, that have age restriction, equal to the given command. Order the titles alphabetically.
           //Read input from the console in your main method, and call your method with the necessary arguments.Print the returned string to the console. Ignore casing of the input.


            if (Enum.TryParse(command, true, out AgeRestriction newCommand))
            {
                var books = context.Books.Where(x => x.AgeRestriction == newCommand)
                    .OrderBy(x => x.Title)
                    .Select(x => new { Title = x.Title })
                    .ToList();

                return String.Join(Environment.NewLine, books);
            }
            return null;
        }
    }
}
