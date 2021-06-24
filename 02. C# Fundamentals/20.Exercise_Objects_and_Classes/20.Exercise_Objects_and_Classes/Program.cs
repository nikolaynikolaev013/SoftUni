using System;
using System.Collections.Generic;

namespace _20.Exercise_Objects_and_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            int howManyToGenerate = int.Parse(Console.ReadLine());

            Data data = new Data();

            for (int i = 0; i < howManyToGenerate; i++)
            {
                Ad ad = new Ad(data.GenerateRandom(0), data.GenerateRandom(1), data.GenerateRandom(2), data.GenerateRandom(3));
                ad.ToString();
            }

        }
    }

    public class Data
    {
        List<string> phrases = new List<string>
            {   "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };

        List<string> events = new List<string>
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

        List<string> authors = new List<string>
        {
            "Diana",
            "Petya",
            "Stella",
            "Elena",
            "Katya",
            "Iva",
            "Annie",
            "Eva"
        };

        List<string> Cities = new List<string>
        {
            "Burgas",
            "Sofia",
            "Plovdiv",
            "Varna",
            "Ruse"
        };


        public string GenerateRandom(int choice)
        {
            Random rand = new Random();

            switch (choice)
            {
                case 0:
                    rand.Next(0, phrases.Count - 1);
                    return phrases[rand.Next(0, phrases.Count - 1)];
                    break;
                case 1:
                    rand.Next(0, events.Count - 1);
                    return events[rand.Next(0, events.Count - 1)];
                    break;
                case 2:
                    rand.Next(0, authors.Count - 1);
                    return authors[rand.Next(0, authors.Count - 1)];
                    break;
                case 3:
                    rand.Next(0, Cities.Count - 1);
                    return Cities[rand.Next(0, Cities.Count - 1)];
                    break;
            }
            return "-1";
        }
    }

    public class Ad
    {
        public string Phrase { get; set; }
        public string Event { get; set; }
        public string Author { get; set; }
        public string City { get; set; }

        public Ad(string ph, string ev, string au, string ci)
        {
            Phrase = ph;
            Event = ev;
            Author = au;
            City = ci;
        }
        
        public void ToString()
        {
            Console.WriteLine($"{this.Phrase} {this.Event} {this.Author} - {this.City}");
        }

    }
}
