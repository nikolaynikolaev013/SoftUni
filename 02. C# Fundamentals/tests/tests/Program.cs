using System;
using System.Linq;

namespace tests
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (arr.Length != 1)
            {
                int[] newArr = new int[arr.Length - 1];


                for (int i = 0; i < newArr.Length ; i++)
                {
                    newArr[i] = arr[i] + arr[i + 1];
                }

                arr = newArr;
            }

            Console.WriteLine(String.Join(" ", arr));


        }
    }
}
