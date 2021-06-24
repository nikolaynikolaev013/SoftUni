using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.Letters_change_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            decimal totalSum = 0.0M;

            foreach (var input in inputs)
            {
                StringBuilder sb = new StringBuilder(input);
                sb.Remove(0, 1);
                sb.Remove(sb.Length - 1, 1);
                int number = int.Parse(sb.ToString());
                decimal total = 0.0M;

                if (Char.IsUpper(input[0]))
                {
                    double letterPos = (int)input[0] - (int)'A' + 1;
                    total = (decimal)(number / letterPos * 1.0);
                }
                else
                {
                    double letterPos = (int)input[0] - (int)'a' + 1;
                    total = (decimal)(number * letterPos * 1.0);
                }

                if (Char.IsUpper(input[input.Length-1]))
                {
                    int letterPos = (int)input[input.Length -1] - (int)'A' + 1;
                    total -= letterPos;
                }
                else
                {
                    int letterPos = (int)input[input.Length-1] - (int)'a' + 1;
                    total += letterPos;
                }

                totalSum += total;
            }

            Console.WriteLine($"{totalSum:F2}");
        }
    }
}
