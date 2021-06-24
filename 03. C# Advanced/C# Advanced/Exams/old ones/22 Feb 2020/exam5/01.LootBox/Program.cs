using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var univInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var firstBox = new Queue<int>(univInput);

            univInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var secondBox = new Stack<int>(univInput);

            var claimedItems = 0;


            while (firstBox.Count > 0 && secondBox.Count > 0)
            {

                var currFirstNumber = firstBox.Peek();
                var currSecondNumber = secondBox.Peek();

                var sum = currFirstNumber + currSecondNumber;

                if (sum % 2 == 0)
                {
                    claimedItems += sum;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(currSecondNumber);
                    secondBox.Pop();
                }
            }

            var emptyBoxString = firstBox.Count == 0 ? "First lootbox is empty" : "Second lootbox is empty";
            var claimedItemsString = claimedItems >= 100 ? $"Your loot was epic! Value: {claimedItems}" : $"Your loot was poor... Value: {claimedItems}";


            Console.WriteLine(emptyBoxString);
            Console.WriteLine(claimedItemsString);
        }
    }
}
