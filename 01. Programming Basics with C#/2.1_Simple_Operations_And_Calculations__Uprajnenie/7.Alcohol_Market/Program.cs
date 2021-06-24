using System;

namespace Alcohol_Market
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.Write("Price of wiskey: ");

            double priceOfWiskey = double.Parse(Console.ReadLine());
            double priceOfRakiya = priceOfWiskey / 2;
            double priceOfWine = priceOfRakiya * 0.6;
            double priceOfBeer = priceOfRakiya * 0.2;

            Console.Write("liters of beer ");
            double litersOfBeer = double.Parse(Console.ReadLine());
            Console.Write("liters of wine ") ;
            double litersOfWine = double.Parse(Console.ReadLine());
            Console.Write("liters of rakiya ");
            double litersOfRakiya = double.Parse(Console.ReadLine());
            Console.Write("liters of whisky ");
            double litersOfWiskey = double.Parse(Console.ReadLine());

            double total = priceOfWiskey * litersOfWiskey + priceOfRakiya * litersOfRakiya + priceOfWine * litersOfWine +
                               priceOfBeer * litersOfBeer;
            Console.WriteLine($"total: {total:F2}");



        }
    }
}
