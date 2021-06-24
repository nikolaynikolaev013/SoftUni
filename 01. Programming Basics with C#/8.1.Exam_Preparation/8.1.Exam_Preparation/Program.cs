using System;

namespace Exam_Preparation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double earnings = double.Parse(Console.ReadLine());
            int numOfMonths = int.Parse(Console.ReadLine());
            double moneyForHer = double.Parse(Console.ReadLine());

            double moneyLeft = (earnings * 0.70) - moneyForHer;
            double percent = (100 / earnings) * moneyLeft;


            Console.WriteLine($"She can save {percent:F2}%");
            Console.WriteLine($"{moneyLeft * numOfMonths:F2}");

        }
    }
}
