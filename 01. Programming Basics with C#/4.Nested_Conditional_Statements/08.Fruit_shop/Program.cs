using System;

namespace Fruit_shop
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string weekDay = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());


            switch (weekDay)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    if (fruit == "banana")
                    {
                        Console.WriteLine($"{2.50*quantity:F2}");
                    }
                    else if (fruit == "apple")
                    {
                        Console.WriteLine($"{1.20 * quantity:F2}");
                    }
                    else if (fruit == "orange")
                    {
                        Console.WriteLine($"{0.85 * quantity:F2}");
                    }
                    else if (fruit == "grapefruit")
                    {
                        Console.WriteLine($"{1.45 * quantity:F2}");
                    }
                    else if (fruit == "kiwi")
                    {
                        Console.WriteLine($"{2.70 * quantity:F2}");
                    }
                    else if (fruit == "pineapple")
                    {
                        Console.WriteLine($"{5.50 * quantity:F2}");
                    }
                    else if (fruit == "grapes")
                    {
                        Console.WriteLine($"{3.85 * quantity:F2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;

                case "Saturday":
                case "Sunday":
                    if (fruit == "banana")
                    {
                        Console.WriteLine($"{2.70 * quantity:F2}");
                    }
                    else if (fruit == "apple")
                    {
                        Console.WriteLine($"{1.25 * quantity:F2}");
                    }
                    else if (fruit == "orange")
                    {
                        Console.WriteLine($"{0.9 * quantity:F2}");
                    }
                    else if (fruit == "grapefruit")
                    {
                        Console.WriteLine($"{1.6 * quantity:F2}");
                    }
                    else if (fruit == "kiwi")
                    {
                        Console.WriteLine($"{3 * quantity:F2}");
                    }
                    else if (fruit == "pineapple")
                    {
                        Console.WriteLine($"{5.60 * quantity:F2}");
                    }
                    else if (fruit == "grapes")
                    {
                        Console.WriteLine($"{4.20 * quantity:F2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}
