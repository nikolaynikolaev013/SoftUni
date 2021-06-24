using System;

namespace _09.Spice_must_flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int days = 0;
            int totalSpice = 0;

            while (yield >= 100)
            {
                if (yield >= 100)
                {
                    totalSpice += yield;
                    days++;
                    yield -= 10;
                }
            }

            if (totalSpice > 0)
            {
                totalSpice -= days * 26 + 26;
            }

            Console.WriteLine(days);
            Console.WriteLine(totalSpice);
        }
    }
}
