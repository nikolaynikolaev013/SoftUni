using System;

namespace Fish_Boat
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double numPeople = int.Parse(Console.ReadLine());

            double finalPrice = 0;

            switch (season)
            {
                case "Spring": finalPrice = 3000;  break;
                case "Summer": 
                case "Autumn": finalPrice = 4200; break;
                case "Winter": finalPrice = 2600; break;
            }

            if (numPeople <= 6)
            {
                finalPrice = finalPrice - (finalPrice * 0.10);
            }
            else if (numPeople <= 11)
            {
                finalPrice = finalPrice - (finalPrice * 0.15);
            }
            else
            {
                finalPrice = finalPrice - (finalPrice * 0.25);
            }

            if (numPeople % 2 == 0 && season != "Autumn")
            {
                finalPrice = finalPrice * 0.95;
            }

            if (budget >= finalPrice)
            {
                Console.WriteLine($"Yes! You have {budget - finalPrice:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {finalPrice - budget:F2} leva.");
            }
        }
    }
}
