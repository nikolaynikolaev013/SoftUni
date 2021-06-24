using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Mid_Exam_29_February_2020_Group_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inventory = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Craft!")
            {
                string[] command = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Collect":
                        Collect(inventory, command[1]);
                        break;
                    case "Drop":
                        Drop(inventory, item: command[1]);
                        break;
                    case "Combine Items":
                        CombineItems(inventory, items: command[1]);
                        break;
                    case "Renew":
                        Renew(inventory, command[1]);
                        break;
                }
            }

            ToString(inventory);
        }

        private static void ToString(List<string> inventory)
        {
            Console.WriteLine(String.Join(", ", inventory));
        }

        private static void Renew(List<string> inventory, string item)
        {
            if (inventory.Contains(item))
            {
                inventory.Remove(item);
                inventory.Add(item);
            }
        }

        private static void CombineItems(List<string> inventory, string items)
        {
            string oldItem = items.Split(":", StringSplitOptions.RemoveEmptyEntries)[0];
            string newItem = items.Split(":", StringSplitOptions.RemoveEmptyEntries)[1];

            if (inventory.Contains(oldItem))
            {
                inventory.Insert(inventory.IndexOf(oldItem) + 1, newItem);
            }

        }

        private static void Drop(List<string> inventory, string item)
        {
            if (inventory.Contains(item))
            {
                inventory.Remove(item);
            }
        }

        private static void Collect(List<string> inventory, string item)
        {
            if (!inventory.Contains(item))
            {
                inventory.Add(item);
            }
        }
    }
}
