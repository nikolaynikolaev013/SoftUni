using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Softuni_exam_results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Student> students = new Dictionary<string, Student>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] command = input.Split("-", StringSplitOptions.RemoveEmptyEntries);

                string user = command[0];

                if (input.Contains("banned"))
                {
                    if (students.ContainsKey(user))
                    {
                        students[user].isBanned = true;
                    }
                    continue;
                }

                string language = command[1];
                int points = int.Parse(command[2]);

                if (!students.ContainsKey(user))
                {
                    students.Add(user, new Student(language, points, false));
                }
                else
                {
                    students[user].Languages.Add(language);
                    students[user].points = Math.Max(students[user].points, points);
                }
            }

            //print
            Console.WriteLine("Results:");
            foreach (var item in students.OrderByDescending(x => x.Value.points).ThenBy(x => x.Key))
            {
                if (!item.Value.isBanned)
                {
                    Console.WriteLine($"{item.Key} | {item.Value.points}");
                }

            }

            Console.WriteLine("Submissions:");

            Dictionary<string, int> langs = new Dictionary<string, int>();
            foreach (var item in students)
            {
                foreach (var lang in item.Value.Languages)
                {
                    if (langs.ContainsKey(lang))
                    {
                        langs[lang]++;
                    }
                    else
                    {
                        langs.Add(lang, 1);
                    }
                }
            }

            foreach (var item in langs.OrderByDescending(x=>x.Value))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }

    class Student
    {
        public List<string> Languages { get; set; }
        public int points { get; set; }
        public bool isBanned { get; set; } = false;


        public Student(string lang, int points, bool isBanned)
        {
            this.Languages = new List<string> { lang };
            this.points =  points;
            this.isBanned = isBanned;
        }
    }
}
