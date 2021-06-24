using System;

namespace Yard_Greening
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double km = double.Parse(Console.ReadLine());

            Console.WriteLine($"The final price is: {(km * 7.61) - (km * 7.61) * 0.18:f2} lv.");
            Console.WriteLine($"The discount is: {(km * 7.61)*0.18:f2} lv.");
        }
    }
}
