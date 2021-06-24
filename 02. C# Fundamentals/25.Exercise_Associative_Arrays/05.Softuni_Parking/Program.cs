using System;
using System.Collections.Generic;

namespace _05.Softuni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsToRegister = int.Parse(Console.ReadLine());
            Dictionary<string, string> cars = new Dictionary<string, string>();


            for (int i = 0; i < carsToRegister; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string user = command[1];

                if (command[0] == "register")
                {
                    string plate = command[2];

                    if (cars.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {plate}");
                    }
                    else
                    {
                        Console.WriteLine($"{user} registered {plate} successfully");
                        cars.Add(user, plate);
                    }
                }

                else if (command[0] == "unregister")
                {
                    if (cars.ContainsKey(user))
                    {
                        Console.WriteLine($"{user} unregistered successfully");
                        cars.Remove(user);
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                }
            }


            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
