using System;

namespace Bachelor_Party
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double moneyForSinger = double.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            double totalMoney = 0;
            int temp = 0;
            int numOfGuests = 0;


            while (command != "The restaurant is full")
            {
                temp = int.Parse(command);

                if (temp < 5)
                {
                    totalMoney += temp * 100;
                }
                else if (temp >= 5)
                {
                    totalMoney += temp * 70;
                }

                numOfGuests += temp;
                command = Console.ReadLine();
            }

            if (totalMoney >= moneyForSinger)
            {
                Console.WriteLine($"You have {numOfGuests} guests and {totalMoney - moneyForSinger} leva left.");
            }
            else
            {
                Console.WriteLine($"You have {numOfGuests} guests and {totalMoney} leva income, but no singer.");
            }

        }
    }
}
