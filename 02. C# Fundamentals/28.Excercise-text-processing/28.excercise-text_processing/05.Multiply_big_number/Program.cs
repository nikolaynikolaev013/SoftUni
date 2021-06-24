using System;
using System.Text;

namespace _05.Multiply_big_number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number1 = Console.ReadLine();
            int number2 = int.Parse(Console.ReadLine());

            if (number2 == 0)
            {
                Console.WriteLine(0);
                return;
            }

            while (number1[0] == 0)
            {
                number1 = number1.Substring(1);
            }

            StringBuilder newNumber = new StringBuilder();

            int remainder = 0;

            for (int i = number1.Length-1; i >= 0; i--)
            {
                int result = int.Parse(number1[i].ToString()) * number2 + remainder;

                if (result > 9)
                {
                    remainder = result / 10;
                    result %= 10;
                }

                newNumber.Append(result- remainder);
            }

            if (remainder != 0)
            {
                newNumber.Append(remainder);
            }
            StringBuilder finalNumber = new StringBuilder();

            for (int i = int.Parse(newNumber.ToString()); i >= 0; i--)
            {
                finalNumber.Append(newNumber[i]);
            }

            Console.WriteLine(finalNumber.ToString());
        }
    }
}
