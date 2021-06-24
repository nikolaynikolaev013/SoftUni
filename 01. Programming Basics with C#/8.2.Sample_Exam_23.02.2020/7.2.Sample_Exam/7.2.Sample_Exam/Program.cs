using System;

namespace Sample_Exam
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double foodMoney = double.Parse(Console.ReadLine());
            double souveneirsMoney = double.Parse(Console.ReadLine());
            double hotelMoney = double.Parse(Console.ReadLine());

            double totalFuelMoney = 420 / 100.0 * 7 * 1.85;
            double totalHotelMoney = (hotelMoney * 0.9) + (hotelMoney * 0.85) + (hotelMoney * 0.8);

            double totalSouveneirsMoney = souveneirsMoney * 3;

            double totalFoodMoney = foodMoney * 3;

            Console.WriteLine($"Money needed: {totalFuelMoney + totalHotelMoney + totalSouveneirsMoney + totalFoodMoney:F2}");
        }
    }
}
