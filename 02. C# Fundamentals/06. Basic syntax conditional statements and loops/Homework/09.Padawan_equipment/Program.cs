using System;

namespace Padawan_equipment
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int howManyStudents = int.Parse(Console.ReadLine());
            double lightSaberPrice = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());

            double totalLightsabers = lightSaberPrice * Math.Ceiling(howManyStudents * 1.10);
            double totalRobes = priceOfRobes * howManyStudents;
            double totalBelts = (howManyStudents - Math.Floor(howManyStudents / 6.0)) * priceOfBelts;

            double totalPrice = totalLightsabers + totalRobes + totalBelts;

            if (budget >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:F2}lv.");
            }
            else if (budget < totalPrice)
            {
                Console.WriteLine($"Ivan Cho will need {totalPrice - budget:F2}lv more.");
            }
        }
    }
}
