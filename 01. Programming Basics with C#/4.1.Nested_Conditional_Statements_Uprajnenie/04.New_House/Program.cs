using System;

namespace New_House
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string typeOfFlower = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double finalPrice = 0;

            switch (typeOfFlower)
            {
                case "Roses":
                    finalPrice = quantity * 5;
                    if (quantity > 80)
                    {
                        finalPrice -= finalPrice * 0.1;
                    }
                    break;
                case "Dahlias":
                    finalPrice = quantity * 3.8;
                    if (quantity > 90)
                    {
                        finalPrice -= finalPrice * 0.15;
                    }
                    break;
                case "Tulips":
                    finalPrice = quantity * 2.8;
                    if (quantity > 80)
                    {
                        finalPrice -= finalPrice * 0.15;
                    }
                    break;
                case "Narcissus":
                    finalPrice = quantity * 3;
                    if (quantity < 120)
                    {
                        finalPrice += finalPrice * 0.15;
                    }
                    break;
                case "Gladiolus":
                    finalPrice = quantity * 2.5;
                    if (quantity <
                        80)
                    {
                        finalPrice += finalPrice * 0.2;
                    }
                    break;
            }

            if (finalPrice <= budget)
            {
                Console.WriteLine($"Hey, you have a great garden with {quantity} {typeOfFlower} and {budget - finalPrice:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {finalPrice - budget:F2} leva more.");
            }

        }
    }
}
