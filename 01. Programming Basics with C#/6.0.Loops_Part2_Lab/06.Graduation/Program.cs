using System;

namespace Graduation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double grade = 0;
            int level = 1;
            double avg = 0;


            while (level <=12)
            {
                grade = double.Parse(Console.ReadLine());

                if (grade >= 4.0)
                {
                    ++level;
                    avg += grade;
                }
            }

            Console.WriteLine($"{name} graduated. Average grade: {avg/12:F2}");

        }
    }
}
