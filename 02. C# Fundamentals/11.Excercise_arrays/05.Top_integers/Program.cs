using System;
using System.Linq;

namespace _05.Top_integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
          

            for (int i = 0; i < arr.Length; i++)
            {
                bool flag = false;

                if (i == arr.Length-1)
                {
                    Console.Write(arr[i] + " ");
                    continue;
                }

                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[j] >= arr[i])
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    Console.Write(arr[i] + " ");
                }
            }
        }
    }
}
