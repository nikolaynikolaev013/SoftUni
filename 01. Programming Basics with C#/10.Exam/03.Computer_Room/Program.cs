using System;

namespace Computer_Room
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int numOfHours = int.Parse(Console.ReadLine());
            int sizeOfGroup = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();

            double hourlyRate = 0;

            switch (month)
            {
                case "march":
                case "april":
                case "may":
                    if (timeOfDay == "day")
                    {
                        hourlyRate = 10.50;
                    }
                    else
                    {
                        hourlyRate = 8.40;
                    }
                    break;

                case "june":
                case "july":
                case "august":
                    if (timeOfDay == "day")
                    {
                        hourlyRate = 12.60;
                    }
                    else
                    {
                        hourlyRate = 10.20;
                    }
                    break;
                default:
                    break;
            }

            if (sizeOfGroup >= 4)
            {
                hourlyRate *= 0.9;
            }

            if (numOfHours >= 5)
            {
                hourlyRate *= 0.5;
            }

            Console.WriteLine($"Price per person for one hour: {hourlyRate:F2}");
            Console.WriteLine($"Total cost of the visit: {hourlyRate * numOfHours * sizeOfGroup:F2}");
        }
    }
}
