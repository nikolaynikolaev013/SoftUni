using System;

namespace Money_Balance
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int numOfPayments = int.Parse(Console.ReadLine());
            int counter = 0;
            double sum = 0;

            double temp = 0;

            while (counter <= numOfPayments-1)
            {
                temp = double.Parse(Console.ReadLine());

                if (temp < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                sum += temp;
                Console.WriteLine($"Increase: {temp:F2}");
                counter++;
            }

            Console.WriteLine($"Total: {sum:F2}");
        }
    }
}
