using System;

namespace Journey
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double price = 0;
            string destination = "";
            string type = "";

            if (budget <= 100)
            {
                destination = "Bulgaria";

                if (season == "summer")
                {
                    price = budget * 0.3;
                    type = "Camp";
                }
                else if (season == "winter")
                {
                    price = budget * 0.7;
                    type = "Hotel";
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";

                if (season == "summer")
                {
                    price = budget * 0.4;
                    type = "Camp";
                }
                else if (season == "winter")
                {
                    price = budget * 0.8;
                    type = "Hotel";
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";

                price = budget * 0.9;
                type = "Hotel";
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{type} - {price:F2}");
        }
    }
}

