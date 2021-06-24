using System;

namespace Sushi_Time
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string sushiType = Console.ReadLine();
            string restaurantName = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());
            char delivery = char.Parse(Console.ReadLine());

            double totalPrice = 0;

            bool invalid = false;


            switch (restaurantName)
            {
                case "Sushi Zone":
                    if (sushiType == "sashimi")
                    {
                        totalPrice = amount * 4.99;
                    }
                    else if (sushiType == "maki")
                    {
                        totalPrice = amount * 5.29;
                    }
                    else if (sushiType == "uramaki")
                    {
                        totalPrice = amount * 5.99;
                    }
                    else if (sushiType == "temaki")
                    {
                        totalPrice = amount * 4.29;
                    }
                    break;

                case "Sushi Time":
                    if (sushiType == "sashimi")
                    {
                        totalPrice = amount * 5.49;
                    }
                    else if (sushiType == "maki")
                    {
                        totalPrice = amount * 4.69;
                    }
                    else if (sushiType == "uramaki")
                    {
                        totalPrice = amount * 4.49;
                    }
                    else if (sushiType == "temaki")
                    {
                        totalPrice = amount * 5.19;
                    }
                    break;

                case "Sushi Bar":
                    if (sushiType == "sashimi")
                    {
                        totalPrice = amount * 5.25;
                    }
                    else if (sushiType == "maki")
                    {
                        totalPrice = amount * 5.55;
                    }
                    else if (sushiType == "uramaki")
                    {
                        totalPrice = amount * 6.25;
                    }
                    else if (sushiType == "temaki")
                    {
                        totalPrice = amount * 4.75;
                    }
                    break;

                case "Asian Pub":
                    if (sushiType == "sashimi")
                    {
                        totalPrice = amount * 4.50;
                    }
                    else if (sushiType == "maki")
                    {
                        totalPrice = amount * 4.80;
                    }
                    else if (sushiType == "uramaki")
                    {
                        totalPrice = amount * 5.50;
                    }
                    else if (sushiType == "temaki")
                    {
                        totalPrice = amount * 5.50;
                    }
                    break;
                default:
                    Console.WriteLine($"{restaurantName} is invalid restaurant!");
                    invalid = true;
                    break;
            }

            if (delivery == 'Y')
            {
                totalPrice *= 1.20;
            }

            if (!invalid)
            {
                Console.WriteLine($"Total price: {Math.Ceiling(totalPrice)} lv.");
            }
        }
    }
}
