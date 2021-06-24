using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Mu_Online
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoins = 0;

            List<string> rooms = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            for (int i = 0; i < rooms.Count; i++)
            {
                string[] currRoom = rooms[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (currRoom[0])
                {
                    case "potion":
                        int oldHealth = health;
                        health += int.Parse(currRoom[1]);
                        if (health > 100)
                        {
                            health = 100;
                        }

                        Console.WriteLine($"You healed for {health - oldHealth} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                        break;
                    case "chest":
                        bitcoins += int.Parse(currRoom[1]);
                        Console.WriteLine($"You found {currRoom[1]} bitcoins.");
                        break;

                    default:
                        string monsterName = currRoom[0];
                        int power = int.Parse(currRoom[1]);

                        health -= power;

                        if (health <= 0)
                        {
                            Console.WriteLine($"You died! Killed by {monsterName}.");
                            Console.WriteLine($"Best room: {i + 1}");
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"You slayed {monsterName}.");
                        }
                        break;
                }
            }

            Console.WriteLine($"You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
