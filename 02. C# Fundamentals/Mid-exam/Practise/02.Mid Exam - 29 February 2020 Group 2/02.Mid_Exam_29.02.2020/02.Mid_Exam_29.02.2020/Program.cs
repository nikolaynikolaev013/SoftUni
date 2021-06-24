using System;

namespace _02.Mid_Exam_29._02._2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int employee1Capabilities = int.Parse(Console.ReadLine());
            int employee2Capabilities = int.Parse(Console.ReadLine());
            int employee3Capabilities = int.Parse(Console.ReadLine());

            int numOfPeople = int.Parse(Console.ReadLine());
            int numOfHours = 0;

            while (numOfPeople > 0)
            {
                numOfHours++;
                if (numOfHours % 4 == 0)
                {
                    numOfHours++;
                }
                numOfPeople -= employee1Capabilities;
                numOfPeople -= employee2Capabilities;
                numOfPeople -= employee3Capabilities;
            }

            Console.WriteLine($"Time needed: {numOfHours}h.");
        }
    }
}
