using System;

namespace Conditional_Statements
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double holidayPrice = double.Parse(Console.ReadLine());
            int numOfPuzzels = int.Parse(Console.ReadLine());
            int numOfDolls = int.Parse(Console.ReadLine());
            int numOfTeddyBears = int.Parse(Console.ReadLine());
            int numOfMinions = int.Parse(Console.ReadLine());
            int numOfTrucks = int.Parse(Console.ReadLine());

            double totalMoney = numOfPuzzels * 2.60 + numOfDolls * 3.0 + numOfTeddyBears * 4.10 + numOfMinions * 8.20 + numOfTrucks * 2.0;

            int numOfToys = numOfPuzzels + numOfDolls + numOfTeddyBears + numOfMinions + numOfTrucks;


            if (numOfToys >= 50)
            {
                totalMoney = totalMoney * 0.75;
            }

            double moneyAfterTaxes = totalMoney * 0.9;


            if (moneyAfterTaxes >= holidayPrice)
            {
                Console.WriteLine($"Yes! {moneyAfterTaxes - holidayPrice:F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {holidayPrice - moneyAfterTaxes:F2} lv needed.");
            }
        }
    }
}
