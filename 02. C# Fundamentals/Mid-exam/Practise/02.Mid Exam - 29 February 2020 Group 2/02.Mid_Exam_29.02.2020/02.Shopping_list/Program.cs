using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Shopping_list
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = Console.ReadLine().Split("!", StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = String.Empty;
            while ((input = Console.ReadLine()) != "Go Shopping!")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Urgent")
                {
                    Urgent(shoppingList, item: command[1]);
                }
                else if (command[0] == "Unnecessary")
                {
                    Unnecessary(shoppingList, item: command[1]);
                }
                else if (command[0] == "Correct")
                {
                    Correct(shoppingList, oldItemName: command[1], newItemName: command[2]);
                }
                else if (command[0] == "Rearrange")
                {
                    Rearrange(shoppingList, item: command[1]);
                }
            }

            ToString(shoppingList);
        }

        private static void ToString(List<string> shoppingList)
        {
            Console.WriteLine(String.Join(", ", shoppingList));
        }

        private static void Rearrange(List<string> shoppingList, string item)
        {
            if (shoppingList.Contains(item))
            {
                string oldItem = item;
                shoppingList.Remove(item);
                shoppingList.Add(oldItem);
            }
        }

        private static void Correct(List<string> shoppingList, string oldItemName, string newItemName)
        {
            if (shoppingList.Contains(oldItemName))
            {
                shoppingList[shoppingList.IndexOf(oldItemName)] = newItemName;
            }
        }

        private static void Unnecessary(List<string> shoppingList, string item)
        {
            if (shoppingList.Contains(item))
            {
                shoppingList.Remove(item);
            }
        }

        private static void Urgent(List<string> shoppingList, string item)
        {
            if (!shoppingList.Contains(item))
            {
                shoppingList.Insert(0, item);
            }
        }
    }
}
