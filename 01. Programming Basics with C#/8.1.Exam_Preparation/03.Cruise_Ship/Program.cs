using System;

namespace Cruise_Ship
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string cabin = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double nightPrice = 0;
            double totalPrice = 0;

            switch (type)
            {
                case "Mediterranean":
                    if (cabin == "standard cabin")
                    {
                        nightPrice = 27.50;
                    }
                    else if (cabin == "cabin with balcony")
                    {
                        nightPrice = 30.20;
                    }
                    else if (cabin == "apartment")
                    {
                        nightPrice = 40.50;
                    }
                    break;

                case "Adriatic":
                    if (cabin == "standard cabin")
                    {
                        nightPrice = 22.99;
                    }
                    else if (cabin == "cabin with balcony")
                    {
                        nightPrice = 25;
                    }
                    else if (cabin == "apartment")
                    {
                        nightPrice = 34.99;
                    }
                    break;

                case "Aegean":
                    if (cabin == "standard cabin")
                    {
                        nightPrice = 23;
                    }
                    else if (cabin == "cabin with balcony")
                    {
                        nightPrice = 26.60;
                    }
                    else if (cabin == "apartment")
                    {
                        nightPrice = 39.80;
                    }
                    break;
                default:
                    break;
            }

            totalPrice = nightPrice * nights * 4;

            if (nights > 7)
            {
                totalPrice *= 0.75;
            }

            Console.WriteLine($"Annie's holiday in the {type} sea costs {totalPrice:F2} lv.");
        }
    }
}
