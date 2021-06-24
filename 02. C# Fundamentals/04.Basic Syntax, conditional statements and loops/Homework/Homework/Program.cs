using System;

namespace Homework
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            double averageGrades = double.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {studentName}, Age: {age}, Grade: {averageGrades:F2}");
        }
    }
}
