using System;

namespace Clever_Lilly
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceW = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int numOfToys = 0;
            double money = 0;
            int moneyStep = 10;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    money += moneyStep;
                    moneyStep += 10;
                    money -= 1;
                }
                else
                {
                    numOfToys++;
                }
            }
            money += (numOfToys * 1.00) * toyPrice;

            if (money >= priceW)
            {
                Console.WriteLine($"Yes! {money - priceW:F2}");
            }
            else
            {
                Console.WriteLine($"No! {priceW - money:F2}");
            }

        }
    }
}
