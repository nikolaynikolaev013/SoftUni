using System;
using System.Linq;

namespace _06.Equal_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool flag = false;

            for (int i = 0; i < arr.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;

                //left loop
                for (int j = 0; j < i; j++)
                {
                    leftSum += arr[j];
                }

                //right loop
                for (int j = i+1; j < arr.Length; j++)
                {
                    rightSum += arr[j];
                }

                if (rightSum == leftSum)
                {
                    Console.WriteLine($"{i} ");
                    flag = true;
                }
            }

            if (!flag)
            {
                Console.WriteLine("no");
            }
        }
    }
}
