using System;
using System.Text.RegularExpressions;

namespace _03.SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^%(?<client>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$";
            string input = String.Empty;
            double totalMoney = 0;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                Regex regex = new Regex(pattern);
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string custumerName = match.Groups["client"].ToString();
                    string product = match.Groups["product"].ToString();
                    double quantity = double.Parse(match.Groups["quantity"].ToString());
                    double price = double.Parse(match.Groups["price"].ToString());

                    if (quantity > 0)
                    {
                        Console.WriteLine($"{custumerName}: {product} - {quantity * price:F2}");
                        totalMoney += quantity * price;
                    }
                }
            }
            Console.WriteLine($"Total income: {totalMoney:F2}");
        }
    }
}
