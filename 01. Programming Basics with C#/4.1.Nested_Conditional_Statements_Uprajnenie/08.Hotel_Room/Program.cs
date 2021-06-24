using System;

namespace Hotel_Room
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double studio = 0;
            double apartament = 0;

            switch (month)
            {
                case "July":
                case "August":
                    studio = 76;
                    apartament = 77;
                    break;

                case "June":
                case "September":
                    studio = 75.20;
                    apartament = 68.70;

                    if (nights > 14)
                    {
                        studio *= 0.8;
                    }
                    break;
                case "October":
                case "May":
                    studio = 50;
                    apartament = 65;

                    if (nights > 14)
                    {
                        studio *= 0.7;
                    }
                    else if (nights > 7)
                    {
                        studio *= 0.95;
                    }
                    break;
            }

            if (nights > 14)
            {
               apartament *= 0.9;
            }

            Console.WriteLine($"Apartment: {apartament * nights:F2} lv.");
            Console.WriteLine($"Studio: {studio * nights:F2} lv.");
        }
    }
}
