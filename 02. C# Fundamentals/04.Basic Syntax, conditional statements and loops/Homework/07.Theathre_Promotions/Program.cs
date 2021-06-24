using System;

namespace Theathre_Promotions
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string enteredWeekdayType = Console.ReadLine();
            int enteredAge = int.Parse(Console.ReadLine());


            switch (enteredWeekdayType)
            {
                case "Weekday":

                    if (enteredAge >= 0 && enteredAge <= 18)
                    {
                        Console.WriteLine("12$|");
                    }
                    else if (enteredAge > 18 && enteredAge <= 64)
                    {
                        Console.WriteLine("18$");
                    }
                    else if (enteredAge > 64 && enteredAge <= 122)
                    {
                        Console.WriteLine("12$");
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                    break;

                case "Weekend":
                    if (enteredAge >= 0 && enteredAge <= 18)
                    {
                        Console.WriteLine("15$|");
                    }
                    else if (enteredAge > 18 && enteredAge <= 64)
                    {
                        Console.WriteLine("20$");
                    }
                    else if (enteredAge > 64 && enteredAge <= 122)
                    {
                        Console.WriteLine("15$");
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                    break;

                case "Holiday":
                    if (enteredAge >= 0 && enteredAge <= 18)
                    {
                        Console.WriteLine("5$|");
                    }
                    else if (enteredAge > 18 && enteredAge <= 64)
                    {
                        Console.WriteLine("12$");
                    }
                    else if (enteredAge > 64 && enteredAge <= 122)
                    {
                        Console.WriteLine("10$");
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }
        }
    }
}
