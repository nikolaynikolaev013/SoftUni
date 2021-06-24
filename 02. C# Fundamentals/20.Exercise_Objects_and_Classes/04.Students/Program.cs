using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                students.Add(new Student(data[0], data[1], decimal.Parse(data[2])));
            }

            students = students.OrderBy(x => x.grade).ToList();
            students.Reverse();

            for (int i = 0; i < students.Count; i++)
            {
                students[i].ToString();
            }

        }
    }

    public class Student
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public decimal grade { get; set; }

        public Student(string firstName, string lastName, decimal grade)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.grade = grade;
        }

        public void ToString()
        {
            Console.WriteLine($"{firstName} {lastName}: {grade}");
        }
    }
}
