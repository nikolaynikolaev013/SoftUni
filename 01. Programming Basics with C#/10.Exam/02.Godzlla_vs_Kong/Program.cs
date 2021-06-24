using System;

namespace Godzlla_vs_Kong
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numOfStatists = int.Parse(Console.ReadLine());
            double priceForOutfit = double.Parse(Console.ReadLine());
            double moneyForStatists = 0;

            double priceDecor = budget * 0.1;


            if (numOfStatists > 150)
            {
                moneyForStatists = numOfStatists * priceForOutfit;
                moneyForStatists *= 0.9;
            }
            else
            {
                moneyForStatists = numOfStatists * priceForOutfit;
            }


            if (priceDecor + moneyForStatists <= budget)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - (priceDecor + moneyForStatists):F2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {(priceDecor + moneyForStatists) - budget:F2} leva more.");
            }
        }
    }
}
