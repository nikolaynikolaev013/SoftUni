using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Student_academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            int howManyStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < howManyStudents; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (students.ContainsKey(name))
                {
                    students[name].Add(grade);
                }
                else
                {
                    students.Add(name, new List<double>{ grade });
                }
            }

            Dictionary<string, double> avgStudents = new Dictionary<string, double>();

            foreach (var item in students)
            {
                avgStudents.Add(item.Key, item.Value.Average());
            }

            foreach (var item in avgStudents.Where(x => x.Value >= 4.50).OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key} -> {item.Value:F2}");
            }
        }
    }
}
