using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());
            List<Article> list = new List<Article>();

            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                list.Add(new Article(data[0], data[1], data[2]));

            }

            string command = Console.ReadLine();

            switch (command.ToLower())
            {
                case "title":
                    list = list.OrderBy(x => x.title).ToList();
                    break;
                case "content":
                    list = list.OrderBy(x => x.content).ToList();
                    break;
                case "author":
                    list = list.OrderBy(x => x.author).ToList();
                    break;
            }

            if (list.Count == 0)
            {
                return;
            }
            for (int i = 0; i < list.Count; i++)
            {
                list[i].ToString();
            }
        }
    }

    public class Article
    {
        public Article()
        {

        }
        public string title { get; set; }
        public string content { get; set; }
        public string author { get; set; }

        public Article(string t, string c, string a)
        {
            title = t;
            content = c;
            author = a;
        }

        public void ToString()
        {
            Console.WriteLine($"{title} - {content}: {author}");
        }
    }
}
