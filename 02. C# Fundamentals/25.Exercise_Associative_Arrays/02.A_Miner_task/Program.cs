using System;
using System.Collections.Generic;

namespace _02.A_Miner_task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "stop")
            {
                string resource = input;
                int quantity = int.Parse(Console.ReadLine());


                if (resources.ContainsKey(resource))
                {
                    resources[resource] += quantity; 
                }
                else
                {
                    resources.Add(resource, quantity);
                }
            }

            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
