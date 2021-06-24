using System;

namespace Vacation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int numOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string weekDay = Console.ReadLine();

            double fare = 0;
            double totalPrice = 0;

            switch (typeOfGroup)
            {
                case "Students":
                    if (weekDay == "Friday")
                    {
                        fare = 8.45;
                    }
                    else if (weekDay == "Saturday")
                    {
                        fare = 9.80;
                    }
                    else if (weekDay == "Sunday")
                    {
                        fare = 10.46;
                    }
                    break;

                case "Business":
                    if (weekDay == "Friday")
                    {
                        fare = 10.90;
                    }
                    else if (weekDay == "Saturday")
                    {
                        fare = 15.60;
                    }
                    else if (weekDay == "Sunday")
                    {
                        fare = 16.00;
                    }
                    break;

                case "Regular":
                    if (weekDay == "Friday")
                    {
                        fare = 15.00;
                    }
                    else if (weekDay == "Saturday")
                    {
                        fare = 20.00;
                    }
                    else if (weekDay == "Sunday")
                    {
                        fare = 22.50;
                    }
                    break;
            }

            totalPrice = numOfPeople * fare;

            if (typeOfGroup == "Students" && numOfPeople >= 30)
            {
                totalPrice *= 0.85;
            }
            else if (typeOfGroup == "Business" && numOfPeople >= 100)
            {
                totalPrice = (numOfPeople - 10) * fare;
            }
            else if (typeOfGroup == "Regular" && numOfPeople >= 10 && numOfPeople <= 20)
            {
                totalPrice *= 0.95;
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");

        }
    }
}
