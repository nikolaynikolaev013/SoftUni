using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Fancy_barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string barcodePattern = @"^@#+(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+$";
            string numbersPattern = @"(?<digit>\d)";

            int numOfBarcodes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfBarcodes; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, barcodePattern);

                if (match.Success)
                {
                    StringBuilder group = new StringBuilder("00");

                    MatchCollection digits = Regex.Matches(input, numbersPattern);
                    if (digits.Count > 0)
                    {
                        group = new StringBuilder();
                        foreach (Match digit in digits)
                        {
                            group.Append(digit.Groups["digit"].Value);
                        }
                    }
                    Console.WriteLine($"Product group: {group}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
