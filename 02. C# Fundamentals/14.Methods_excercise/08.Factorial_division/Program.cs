using System;

namespace _08.Factorial_division
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            decimal sum = DevideNumbers(FactorialCalculator(n1), FactorialCalculator(n2));

            Console.WriteLine($"{sum:F2}");
        }

        static decimal FactorialCalculator(int num)
        {
            decimal factoriel = 1;

            for (int i = 1; i <= num; i++)
            {
                factoriel *= i;
            }

            return factoriel;
        }
        static decimal DevideNumbers(decimal n1, decimal n2)
        {
            return n1 / n2;
        }
    }
}
