using System;

namespace Summer_Shopping
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double towelPrice = double.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            double umbrellaPrice = (towelPrice / 3) * 2;
            double slippersPrice = umbrellaPrice * 0.75;
            double bag = ((slippersPrice + towelPrice) / 3);

            double totalPrice = towelPrice + umbrellaPrice + slippersPrice + bag;
            double totalWithDiscount = totalPrice - totalPrice * (discount / 100);

            if (totalWithDiscount <= budget)
            {
                Console.WriteLine($"Annie's sum is {totalWithDiscount:F2} lv. She has {budget - totalWithDiscount:F2} lv. left.");
            }
            else
            {
                Console.WriteLine($"Annie's sum is {totalWithDiscount:F2} lv. She needs {totalWithDiscount - budget:F2} lv. more.");
            }

        }
    }
}
