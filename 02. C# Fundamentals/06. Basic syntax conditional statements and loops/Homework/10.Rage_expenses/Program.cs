using System;

namespace Rage_Expenses
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double priceHeadset = double.Parse(Console.ReadLine());
            double priceMouse = double.Parse(Console.ReadLine());
            double priceKeyboard = double.Parse(Console.ReadLine());
            double priceDisplay = double.Parse(Console.ReadLine());

            double howManyHeadset = Math.Floor(lostGames/2.0);
            double howManyMouse = Math.Floor(lostGames/3.0);
            double howManyKeyboard = Math.Floor(lostGames/6.0);
            double howManyDisplays = Math.Floor(howManyKeyboard/2.0);

            double totalExpenses = howManyHeadset * priceHeadset + howManyMouse * priceMouse + howManyKeyboard * priceKeyboard + howManyDisplays * priceDisplay;

            Console.WriteLine($"Rage expenses: {totalExpenses:F2} lv.");
        }
    }
}
