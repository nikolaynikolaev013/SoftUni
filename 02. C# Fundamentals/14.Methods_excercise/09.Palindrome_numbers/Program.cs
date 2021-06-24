using System;
using System.Linq;
using System.Text;

namespace _09.Palindrome_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                Console.WriteLine(PalindromeChecker(input).ToString().ToLower());

                input = Console.ReadLine();
            }
        }

        static bool PalindromeChecker(string num)
        {
            StringBuilder rev = new StringBuilder();

            for (int i = 0; i < num.Length; i++)
            {
                rev.Append(num[num.Length - 1 - i]);
            }

            if (num == rev.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
