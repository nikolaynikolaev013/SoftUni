using System;

namespace Cruise_Games
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string playerName = Console.ReadLine();
            int numOfGamesPlayed = int.Parse(Console.ReadLine());

            double totalPoints = 0;

            int volley = 0;
            int tennis = 0;
            int badminton = 0;

            double totalVolley = 0;
            double totalTennis = 0;
            double totalBadminton = 0;

            for (int i = 0; i < numOfGamesPlayed; i++)
            {
                string gameName = Console.ReadLine();
                int numOfPoints = int.Parse(Console.ReadLine());

                switch (gameName)
                {
                    case "volleyball":
                        volley++;
                        totalVolley += numOfPoints * 1.07;
                        break;
                    case "tennis":
                        tennis++;
                        totalTennis += numOfPoints * 1.05;
                         break;
                    case "badminton":
                        badminton++;
                        totalBadminton += numOfPoints * 1.02;
                        break;
                    default:
                        break;
                }
            }



            if (totalBadminton / badminton >= 75 && totalTennis / tennis >= 75 && totalVolley / volley >= 75)
            {
                Console.WriteLine($"Congratulations, {playerName}! You won the cruise games with {Math.Floor(totalVolley + totalTennis + totalBadminton)} points.");
            }
            else
            {
                Console.WriteLine($"Sorry, {playerName}, you lost. Your points are only {Math.Floor(totalVolley + totalTennis + totalBadminton)}.");
            }
        }
    }
}
