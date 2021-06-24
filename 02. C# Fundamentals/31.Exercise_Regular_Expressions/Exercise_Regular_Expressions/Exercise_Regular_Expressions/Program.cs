using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Exercise_Regular_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<item>[a-zA-Z]*)<<(?<price>(\d*|.)*)!(?<quantity>\d*)";
            string input = String.Empty;

            List<string> furniture = new List<string>();
            double totalPrice = 0;

            while ((input = Console.ReadLine()) != "Purchase")
            {

                Regex reg = new Regex(pattern);
                Match match = reg.Match(input);

                if (match.Success)
                {
                    furniture.Add(match.Groups["item"].Value);
                    if (double.Parse(match.Groups["quantity"].Value) > 0)
                    {
                        totalPrice += double.Parse(match.Groups["price"].Value) * double.Parse(match.Groups["quantity"].Value);
                    }
                }
            }


            Console.WriteLine("Bought furniture:");
            if (furniture.Count > 0)
            {
                Console.WriteLine(String.Join(Environment.NewLine, furniture));
            }

            Console.WriteLine($"Total money spend: {totalPrice:F2}");
        }
    }
}
