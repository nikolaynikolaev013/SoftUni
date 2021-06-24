using System;

namespace Summer_Outfit
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double deg = double.Parse(Console.ReadLine());
            string time = Console.ReadLine();

            string outfit = "";
            string shoes = "";

            switch (time)
            {
                case "Morning":
                    if (deg >= 10 && deg <= 18)
                    {
                        outfit = "Sweatshirt";
                        shoes = "Sneakers";
                    }
                    else if (deg > 18 && deg <= 24)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (deg >= 25)
                    {
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                    }
                    break;
                case "Afternoon":
                    if (deg >= 10 && deg <= 18)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (deg > 18 && deg <= 24)
                    {
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                    }
                    else if (deg >= 25)
                    {
                        outfit = "Swim Suit";
                        shoes = "Barefoot";
                    }
                    break;
                case "Evening":
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    break;
            }

            Console.WriteLine($"It's {deg} degrees, get your {outfit} and {shoes}.");
        }
    }
}
