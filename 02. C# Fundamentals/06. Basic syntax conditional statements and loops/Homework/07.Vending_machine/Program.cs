using System;

namespace Vending_Machine
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();

            double totalMoney = 0;
            double temp = 0;

            double priceNuts = 2;
            double priceWater = 0.7;
            double priceCrisps = 1.5;
            double priceSoda = 0.8;
            double priceCoke = 1;


            while (command != "Start")
            {
                temp = double.Parse(command);
                if (temp == 0.1 || temp == 0.2 || temp == 0.5 || temp == 1 || temp == 2)
                {
                    totalMoney += temp;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {temp}");
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

                while (command != "End")
                {
                    switch (command)
                    {
                        case "Nuts":
                            if (totalMoney >= priceNuts)
                            {
                                Console.WriteLine("Purchased nuts");
                                totalMoney -= priceNuts;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            break;
                        case "Water":
                            if (totalMoney >= priceWater)
                            {
                                Console.WriteLine("Purchased water");
                                totalMoney -= priceWater;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            break;
                        case "Crisps":
                            if (totalMoney >= priceCrisps)
                            {
                                Console.WriteLine("Purchased crisps");
                                totalMoney -= priceCrisps;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            break;
                        case "Soda":
                            if (totalMoney >= priceSoda)
                            {
                                Console.WriteLine("Purchased soda");
                                totalMoney -= priceSoda;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            break;
                        case "Coke":
                            if (totalMoney >= priceCoke)
                            {
                                Console.WriteLine("Purchased coke");
                                totalMoney -= priceCoke;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid product");
                            break;
                    }

                    command = Console.ReadLine();
                }

                Console.WriteLine($"Change: {totalMoney:F2}");
        }
    }
}
