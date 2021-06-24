using System;

namespace Baking_Competition
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int numOfBakers = int.Parse(Console.ReadLine());

            string bakerName = "";
            string type = "";

            string temp = "";

            int amountCookies = 0;
            int amountCakes = 0;
            int amountWaffles = 0;

            double totalMoney = 0;
            int totalAmountBaked = 0;

            for (int i = 0; i < numOfBakers; i++)
            {

                amountCakes = 0;
                amountWaffles = 0;
                amountCookies = 0;


                bakerName = Console.ReadLine();
                type = Console.ReadLine();

                while (type != "Stop baking!")
                {
                    temp = Console.ReadLine();
                    totalAmountBaked += int.Parse(temp);

                    switch (type)
                    {
                        case "cookies":
                            amountCookies += int.Parse(temp);
                            totalMoney += int.Parse(temp) * 1.50;
                            break;

                        case "cakes":
                            amountCakes += int.Parse(temp);
                            totalMoney += int.Parse(temp) * 7.80;
                            break;

                        case "waffles":
                            amountWaffles += int.Parse(temp);
                            totalMoney += int.Parse(temp) * 2.30;
                            break;

                        default:
                            break;
                    }

                    type = Console.ReadLine();
                }

                Console.WriteLine($"{bakerName} baked {amountCookies} cookies, {amountCakes} cakes and {amountWaffles} waffles.");
            }

            Console.WriteLine($"All bakery sold: {totalAmountBaked}");
            Console.WriteLine($"Total sum for charity: {totalMoney:F2} lv.");
        }
    }
}
