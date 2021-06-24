using System;

namespace Nested_Conditional_Statements
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string feedback = Console.ReadLine();

            double discount = 0;
            double finalPrice = 0;

            switch (roomType)
            {
                case "room for one person": finalPrice = (days - 1) * 18; break;
                case "apartment": finalPrice = (days - 1) * 25; break;
                case "president apartment": finalPrice = (days - 1) * 35; break;
            }

            if (days < 10)
            {
                switch (roomType)
                {
                    case "room for one person": discount = 0; break;
                    case "apartment": discount = 0.30; break;
                    case "president apartment": discount = 0.10; break;
                }
            }
            else if (days >= 10 && days <= 15)
            {
                switch (roomType)
                {
                    case "room for one person": discount = 0; break;
                    case "apartment": discount = 0.35; break;
                    case "president apartment": discount = 0.15; break;
                }
            }
            else if (days > 15)
            {
                switch (roomType)
                {
                    case "room for one person": discount = 0; break;
                    case "apartment": discount = 0.50; break;
                    case "president apartment": discount = 0.20; break;
                }
            }

            finalPrice -= finalPrice * discount;

            if (feedback == "positive")
            {
                finalPrice = finalPrice * 1.25;
            }
            else
            {
                finalPrice = finalPrice * 0.9;
            }

            Console.WriteLine($"{finalPrice:F2}");
            
        }
    }
}
