using System;

namespace _05.Add_and_substract
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Substract(Sum(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())), int.Parse(Console.ReadLine())));
        }

        static int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        static int Substract(int num1, int num2)
        {
            return num1 - num2;
        }
    }
}
