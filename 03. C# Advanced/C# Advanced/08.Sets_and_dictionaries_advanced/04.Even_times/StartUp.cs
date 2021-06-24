using System;
using System.Collections.Generic;

namespace _04.Even_times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<int, int>();


            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (dict.ContainsKey(input))
                {
                    dict[input]++;
                }
                else
                {
                    dict.Add(input, 1);
                }
            }

            foreach (var item in dict)
            {
                if (item.Value != 0 && item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                    break;
                }
            }
        }
    }
}
