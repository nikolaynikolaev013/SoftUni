using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05.Fashion_boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int capacity = int.Parse(Console.ReadLine());

            Stack<int> clothes = new Stack<int>(numbers);

            int sum = 0;
            int racks = 0;
            int current = 0;

            while (clothes.Count > 0)
            {
                current = clothes.Peek();

                sum += current;

                if (sum >= capacity)
                {
                    if (sum > clothes.Count)
                    {
                        sum -= clothes.Peek();
                    }
                    else
                    {
                        current = 0;
                    }
                    clothes.Pop();
                    sum = 0;
                    racks++;
                }
            }

            if (sum > 0)
            {
                racks++;
            }


            Console.WriteLine(racks);
        }
    }
}
