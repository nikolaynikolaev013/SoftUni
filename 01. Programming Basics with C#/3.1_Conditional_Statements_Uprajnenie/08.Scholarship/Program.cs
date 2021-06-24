using System;

namespace Scholarship
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double earnings = double.Parse(Console.ReadLine());
            double avgGrades = double.Parse(Console.ReadLine());
            double minWorkingSalary = double.Parse(Console.ReadLine());

           
            double excellentResultAmount = 0;
            double socialResultAmount = 0;

;            if (avgGrades >= 5.50)
            {
                excellentResultAmount = avgGrades * 25;
            }

            if (earnings < minWorkingSalary && avgGrades > 4.50)
            {
                socialResultAmount = minWorkingSalary * 0.35;
            }




            if (socialResultAmount == 0.0 && excellentResultAmount == 0.0)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (socialResultAmount < excellentResultAmount || socialResultAmount == excellentResultAmount)
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excellentResultAmount)} BGN");
            }
            else if (socialResultAmount > excellentResultAmount)
            {
                Console.WriteLine($"You get a Social scholarship {Math.Floor(socialResultAmount)} BGN");
            }
        }
    }
}
