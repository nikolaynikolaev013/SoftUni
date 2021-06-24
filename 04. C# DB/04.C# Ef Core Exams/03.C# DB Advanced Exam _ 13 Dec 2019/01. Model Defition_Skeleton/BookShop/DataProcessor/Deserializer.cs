namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var booksDto = XmlConverter.Deserializer<BookxXmlImportModel>(xmlString, "Books");
            var sb = new StringBuilder();
            var books = new List<Book>();

            foreach (var book in booksDto)
            {
                var dateValid = DateTime.TryParseExact(book.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date);

                if (!IsValid(book) ||
                    !dateValid)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }
                var currBook = new Book
                {
                    Name = book.Name,
                    Genre = (Genre)book.Genre,
                    Price = book.Price,
                    Pages = book.Pages,
                    PublishedOn = date
                };

                sb.AppendLine($"Successfully imported book {currBook.Name} for {currBook.Price:F2}.");
                books.Add(currBook);
            }
            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var authorsDto = JsonConvert.DeserializeObject<AuthorsJsonImportModel[]>(jsonString);
            var authors = new List<Author>();

            foreach (var author in authorsDto)
            {
                var emails = context.Authors.Select(x => x.Email).ToList();
                if (!IsValid(author) ||
                    emails.Contains(author.Email) ||
                    !author.Books.Any())
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var currAuthor = new Author
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Email = author.Email,
                    Phone = author.Phone
                };

                foreach(var book in author.Books)
                {
                    var authorBook = context.Books.FirstOrDefault(x => x.Id == book.Id);
                    if (authorBook != null)
                    {
                        currAuthor.AuthorsBooks.Add(new AuthorBook {
                            Author = currAuthor,
                            Book = authorBook
                        });
                    }
                }

                if (!currAuthor.AuthorsBooks.Any())
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }
                sb.AppendLine($"Successfully imported author - {currAuthor.FirstName + " " + currAuthor.LastName} with {currAuthor.AuthorsBooks.Count} books.");
                context.Authors.Add(currAuthor);
                context.SaveChanges();
            }


            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}