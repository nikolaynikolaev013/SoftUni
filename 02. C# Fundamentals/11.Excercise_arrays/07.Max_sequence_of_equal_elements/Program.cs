using System;
using System.Linq;

namespace _07.Max_sequence_of_equal_elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int biggestSequence = 0;
            int sequence = 1;

            int start = 0;
            int realStart = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == arr[i-1])
                {
                    sequence++;
                    start = i;
                }
                else
                {
                    start -= sequence - 1;
                    sequence = 1;
                }

                if (biggestSequence < sequence)
                {
                    biggestSequence = sequence;
                    realStart = start - (sequence - 1);
                }
                }

            for (int i = realStart; i < realStart + biggestSequence; i++)
            {
                Console.Write(arr[i]+" ");
            }
        }//2 1 1 2 3 3 2 2 2 1
    }
}

