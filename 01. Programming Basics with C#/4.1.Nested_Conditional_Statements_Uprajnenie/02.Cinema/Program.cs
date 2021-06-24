using System;

namespace Cinema
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            double profit = 0;

            if (type == "Premiere")
            {
                profit = (rows * cols) * 12;
            }
            else if (type == "Normal")
            {
                profit = (rows * cols) * 7.5;
            }
            else if (type == "Discount")
            {
                profit = (rows * cols) * 5;
            }

            Console.WriteLine($"{profit:F2} leva");

        }
    }
}
