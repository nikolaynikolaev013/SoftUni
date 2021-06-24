using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Heart_delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> houses = Console.ReadLine().Split("@", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string input = String.Empty;
            int currPossition = 0;

            while ((input = Console.ReadLine()) != "Love!")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Jump(houses, length: int.Parse(command[1]), ref currPossition);

            }

            ToString(houses, currPossition);
        }

        private static void ToString(List<int> houses, int currPossition)
        {

            Console.WriteLine($"Cupid's last position was {currPossition}.");

            int failedHouses = 0;

            for (int i = 0; i < houses.Count; i++)
            {
                if (houses[i] > 0)
                {
                    failedHouses++;
                }
            }

            if (failedHouses > 0)
            {
                Console.WriteLine($"Cupid has failed {failedHouses} places.");
            }
            else
            {
                Console.WriteLine("Mission was successful.");
            }
        }

        private static void Jump(List<int> houses, int length, ref int currPosition)
        {
            
            if (currPosition + length >= houses.Count)
            {
                currPosition = 0;
            }
            else
            {
                currPosition += length;
            }

            if (houses[currPosition] == 0)
            {
                Console.WriteLine($"Place {currPosition} already had Valentine's day.");
                return;
            }

            houses[currPosition] -= 2;

            if (houses[currPosition] == 0)
            {
                Console.WriteLine($"Place {currPosition} has Valentine's day.");
            }
        }
    }
}
