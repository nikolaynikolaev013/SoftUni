using System;

namespace _10.Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            for (int i = 1; i <= n; i++)
            {
                if (CheckIfTopNumber(i))
                {
                    Console.WriteLine(i);
                }
            }

        }

        static bool CheckIfTopNumber(int n)
        {
            if (CheckIfDivisible(n) && CheckForOddDigit(n))
            {
                return true;
            }
            return false;
        }

        static bool CheckIfDivisible(int n)
        {
            int sum = 0;

            for (int i = 0; i < n.ToString().Length; i++)
            {
                sum += int.Parse(n.ToString()[i].ToString());
            }
            if (sum % 8 == 0)
            {
                return true;
            }

            return false;
        }

        static bool CheckForOddDigit(int n)
        {
            string number = n.ToString();


            for (int i = 0; i < number.Length; i++)
            {
                if (int.Parse(number[i].ToString()) % 2 != 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
