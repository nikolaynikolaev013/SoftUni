using System;

namespace Graduation_Part2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int level = 1;
            double temp = 0;
            double grades = 0;
            int f = 0;

            while (level <= 12)
            {
                temp = double.Parse(Console.ReadLine());

                if (temp >= 4)
                {
                    grades += temp;
                    level++;
                }
                else
                {
                    f++;
                }

                if (f > 1)
                {
                    break;
                }
            }

            if (f > 1)
            {
                Console.WriteLine($"{name} has been excluded at {level} grade");
            }
            else
            {
                Console.WriteLine($"{name} graduated. Average grade: {grades/12:F2}");
            }
        }
    }
}
