using System;

namespace Voleyball
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string yearType = Console.ReadLine();
            double p = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            
            double total = 48 - h;
            total *= (3.0 / 4.0);
            total += h;

            total += p * (2.0 / 3.0);

            if (yearType == "leap")
            {
                total *= 1.15;
            }

            Console.WriteLine(Math.Floor(total));

        }
    }
}
