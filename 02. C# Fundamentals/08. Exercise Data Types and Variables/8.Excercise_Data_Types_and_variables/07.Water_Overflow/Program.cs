using System;

namespace _07.Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            ushort liters = 0;
            int temp = 0;

            for (int i = 0; i < n; i++)
            {
                temp = int.Parse(Console.ReadLine());
                if (liters + temp > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    liters += (ushort)temp;
                }
            }

            Console.WriteLine(liters);
        }
    }
}
