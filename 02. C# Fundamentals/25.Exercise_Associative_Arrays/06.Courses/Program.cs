using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string name = command[0];
                string student = command[1];

                if (courses.ContainsKey(name))
                {
                    courses[name].Add(student);
                }
                else
                {
                    courses.Add(name, new List<string> { student });
                }
            }

            foreach (var item in courses.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                foreach (var student in item.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
