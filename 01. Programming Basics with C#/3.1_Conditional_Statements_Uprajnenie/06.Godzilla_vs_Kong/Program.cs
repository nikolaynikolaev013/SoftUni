using System;

namespace Godzilla_vs_Kong
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double statistOutfitPrice = double.Parse(Console.ReadLine());

            double statistsMoney = statists * statistOutfitPrice;
            double decorPrice = budget * 0.1;

            if (statists > 150)
            {
                statistsMoney *= 0.9;
            }

            if (budget < statistsMoney + decorPrice)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {(statistsMoney + decorPrice) - budget:F2} leva more.");
            }
            else if (budget >= statistsMoney + decorPrice)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - (statistsMoney + decorPrice):F2} leva left.");
            }
        }
    }
}
