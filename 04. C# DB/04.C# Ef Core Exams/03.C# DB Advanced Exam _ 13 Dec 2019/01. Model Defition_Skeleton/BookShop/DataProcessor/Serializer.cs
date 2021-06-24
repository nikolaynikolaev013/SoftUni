namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            //Select all authors along with their books.Select their name in format first name + ' ' + last name.For each book select its name and price formatted to the second digit after the decimal point. Order the books by price in descending order. Finally sort all authors by book count descending and then by author full name.
            //NOTE: Before the orders, materialize the query(This is issue by Microsoft in InMemory database library)!!!

            var authors = context.Authors
                .ToList()
                .Select(x => new
                {
                    AuthorName = x.FirstName + " " + x.LastName,
                    Books = x.AuthorsBooks.Select(b => new
                    {
                        BookName = b.Book.Name,
                        BookPrice = b.Book.Price.Value.ToString("F2")
                    })
                    .OrderByDescending(b => double.Parse(b.BookPrice))
                    .ToList()
                })
                .OrderByDescending(x => x.Books.Count())
                .ThenBy(x => x.AuthorName)
                .ToList();

            return JsonConvert.SerializeObject(authors, Formatting.Indented);

        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            //Export top 10 oldest books that are published before the given date and are of type science. For each book select its name, date (in format "d") and pages. Sort them by pages in descending order and then by date in descending order.

            var books = context.Books.Where(x => x.PublishedOn < date && x.Genre == Data.Models.Enums.Genre.Science)
                .ToList()
                .Select(x => new BooksXmlExportModel()
                {
                    Pages = (int)x.Pages,
                    Name = x.Name,
                    PublishedOn = x.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                })
                .OrderByDescending(x => x.Pages)
                .ThenByDescending(x => x.PublishedOn)
                .Take(10)
                .ToArray();

            return XmlConverter.Serialize<BooksXmlExportModel>(books, "Books");
        }
    }
}