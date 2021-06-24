using System;

namespace Charity_Campaign
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int howMuchDays = int.Parse(Console.ReadLine());
            int numOfBakers = int.Parse(Console.ReadLine());
            int howManyCakes = int.Parse(Console.ReadLine());
            int howManyWaffles = int.Parse(Console.ReadLine());
            int howManyPancakes = int.Parse(Console.ReadLine());

            double cakesFunds = howManyCakes * 45.0;
            double wafflesFunds = howManyWaffles * 5.80;
            double PancakesFunds = howManyPancakes * 3.20;

            double allMoney = (cakesFunds + wafflesFunds + PancakesFunds)*howMuchDays * numOfBakers;
            Console.WriteLine($"{allMoney - allMoney/8:F2}");


        }
    }
}
