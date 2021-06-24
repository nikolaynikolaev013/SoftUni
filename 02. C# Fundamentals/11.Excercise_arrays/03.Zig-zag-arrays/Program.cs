using System;
using System.Linq;

namespace _03.Zig_zag_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr1 = new int[n];
            int[] arr2 = new int[n];

            int[] input = new int[2];
            bool invert = false;

            for (int i = 0; i < arr1.Length; i++)
            {
                if (!invert)
                {
                    input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    arr1[i] = input[0];
                    arr2[i] = input[1];
                    invert = !invert;
                }
                else if (invert)
                {
                    input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    arr2[i] = input[0];
                    arr1[i] = input[1];
                    invert = !invert;
                }
            }

            Console.WriteLine(String.Join(" ", arr1));
            Console.WriteLine(String.Join(" ", arr2));

        }
    }
}
