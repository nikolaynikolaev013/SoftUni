using System;

namespace _05._07._2020_Mid_Exam_real
{
    class Program
    {
        static void Main(string[] args)
        {
            int emp1Capacity = int.Parse(Console.ReadLine());
            int emp2Capacity = int.Parse(Console.ReadLine());
            int emp3Capacity = int.Parse(Console.ReadLine());

            int numOfStudents = int.Parse(Console.ReadLine());
            int numOfHours = 0;

            while (numOfStudents > 0)
            {
                numOfHours++;

                if (numOfHours % 4 == 0)
                {
                    numOfHours++;
                }

                numOfStudents -= emp1Capacity;
                numOfStudents -= emp2Capacity;
                numOfStudents -= emp3Capacity;
            }

            Console.WriteLine($"Time needed: {numOfHours}h.");
        }
    }
}
