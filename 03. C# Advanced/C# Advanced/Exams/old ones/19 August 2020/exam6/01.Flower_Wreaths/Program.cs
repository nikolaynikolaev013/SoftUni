using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            var univInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lilies = new Stack<int>(univInput);

            univInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var roses = new Queue<int>(univInput);

            var numOfWreaths = 0;
            var storedFlowers = 0;

            while (roses.Count > 0 && lilies.Count > 0)
            {

                var currRose = roses.Peek();
                var currLilie = lilies.Peek();
                var sum = currRose + currLilie;

                if (sum == 15)
                {
                    roses.Dequeue();
                    lilies.Pop();
                    numOfWreaths++;
                }
                else if (sum > 15)
                {
                    lilies.Push(lilies.Pop() - 2);
                }
                else
                {
                    storedFlowers += currRose;
                    storedFlowers += currLilie;
                    roses.Dequeue();
                    lilies.Pop();
                }
            }

            numOfWreaths += storedFlowers / 15;

            var madeItOrNotString = numOfWreaths >= 5 ? $"You made it, you are going to the competition with {numOfWreaths} wreaths!"
                : $"You didn't make it, you need {5 - numOfWreaths} wreaths more!";

            Console.WriteLine(madeItOrNotString);
        }

    }
}
