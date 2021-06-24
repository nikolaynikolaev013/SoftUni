using System;
using System.Linq;

namespace _14.Methods_excercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            int[] arr = { number1, number2, number3 };

            Console.WriteLine(ReturnTheSmallest(arr));

        }
        

        static int ReturnTheSmallest(int[] arr)
        {
            int smallest = int.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < smallest)
                {
                    smallest = arr[i];
                }
            }

            return smallest;

                
        }
    }
}
