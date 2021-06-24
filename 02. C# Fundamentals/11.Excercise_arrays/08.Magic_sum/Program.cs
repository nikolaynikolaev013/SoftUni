using System;
using System.Linq;

namespace _08.Magic_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i+1; j < array.Length; j++)
                {
                    if (array[i] + array[j] == num)
                    {
                            Console.WriteLine($"{array[i]} {array[j]}");
                    }
                }
            }//14 20 60 13 7 19 8

        }
    }
}
