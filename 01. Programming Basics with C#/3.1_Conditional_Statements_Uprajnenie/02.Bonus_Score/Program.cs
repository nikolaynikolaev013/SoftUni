using System;

namespace Bonus_Score
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int points = int.Parse(Console.ReadLine());
            double bonus;


            if (points > 1000)
            {
                bonus = points * 0.1;
            }
            else if (points > 100)
            {
                bonus = points * 0.2;
            }
            else
            {
                bonus = 5;
            }

            if (points % 2 == 0)
            {
                bonus += 1;
            }
            else if (points % 10 == 5)
            {
                bonus += 2;
            }

            Console.WriteLine(bonus);
            Console.WriteLine(Math.Round(bonus + points, 2));
        }
    }
}
