using System;

namespace Travelling
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string destination = "";
            double price = 0;
            double sum = 0;
            double temp = 0;

            while (command != "End")
            {
                destination = command;
                price = double.Parse(Console.ReadLine());

                while (sum < price)
                {
                    temp = double.Parse(Console.ReadLine());
                    sum += temp;

                    if (sum >= price)
                    {
                        Console.WriteLine($"Going to {destination}!");
                        sum = 0;
                        price = 0;
                        destination = "";
                        break;
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}
