using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Border_Control
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var persons = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (command.Length == 4)
                {
                    persons.Add(new Citizen(command[0], int.Parse(command[1]), command[2], command[3]));
                }
                else
                {
                    persons.Add(new Rebel(command[0], int.Parse(command[1])));
                }
            }


            var input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                var buyer = persons.FirstOrDefault(x => x.Name == input);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            Console.WriteLine(persons.Sum(x=>x.Food));

        }
    }
}
