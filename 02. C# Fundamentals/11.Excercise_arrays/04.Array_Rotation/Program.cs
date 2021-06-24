using System;
using System.Linq;

namespace _04.Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numRotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numRotations; i++)
            {
                int temp = arr[0];

                for (int j = 0; j < arr.Length; j++)
                {
                    if (j+1 >= arr.Length)
                    {
                        arr[j] = temp;
                        continue;
                    }
                    arr[j] = arr[j+1];
                }
            }

            Console.WriteLine(String.Join(" ", arr));
        }
    }
}
