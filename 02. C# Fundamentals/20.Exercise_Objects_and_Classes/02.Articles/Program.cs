using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Article article = new Article(data[0], data[1], data[2]);
            int n = int.Parse(Console.ReadLine());

            
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0].ToLower() == "edit")
                {
                    article.Edit(command[1]);
                }
                else if (command[0].ToLower() == "changeauthor")
                {
                    article.ChangeAuthor(command[1]);
                }
                else if (command[0].ToLower() == "rename")
                {
                    article.Rename(command[1]);
                }
            }

            article.ToString();


        }
    }

    public class Article
    {
        //      •	Title – a string
        //      •	Content – a string
        //      •	Author – a string


        public string title { get; set; }
        public string content { get; set; }
        public string author { get; set; }

        public Article(string t, string c, string a)
        {
            title = t;
            content = c;
            author = a;
        }

        //•	Edit (new content) – change the old content with the new one

        public void Edit(string c)
        {
            content = c;
        }

        //•	ChangeAuthor (new author) – change the author
        public void ChangeAuthor(string author)
        {
            this.author = author;
        }

        //•	Rename (new title) – change the title of the article
        public void Rename(string title)
        {
            this.title = title;
        }

        //•	Override the ToString method – print the article in the following format: 
        //"{title} - {content}: {autor}"

        public void ToString()
        {
            Console.WriteLine($"{title} - {content}: {author}");
        }
    }
}
