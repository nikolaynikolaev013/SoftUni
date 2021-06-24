using System;
using System.Linq;

namespace _02.Telephony
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var websites = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var smartphone = new Smartphone();
            var stationaryPhone = new StationaryPhone();

            foreach (var number in numbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(number));
                    }
                    else
                    {
                        Console.WriteLine(smartphone.Call(number));
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            foreach (var site in websites)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(site));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
