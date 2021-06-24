using System;
using System.Text;

namespace _06.Middle_characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(PrintTheMiddleCharrs(input));
        }

        static string PrintTheMiddleCharrs(string input)
        {
            StringBuilder str = new StringBuilder();

            if (input.Length % 2 == 0)
            {
                str.Append(input[input.Length / 2 - 1].ToString());
                str.Append(input[input.Length / 2].ToString());
                return str.ToString();
            }
            else
            {
                str.Append(input[input.Length / 2]);
                return str.ToString();
            }
        }
    }
}
