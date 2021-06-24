using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfHeroes = int.Parse(Console.ReadLine());

            Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>();

            for (int i = 0; i < numOfHeroes; i++)
            {
                string[] heroInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = heroInput[0];
                int hp = int.Parse(heroInput[1]);
                int mp = int.Parse(heroInput[2]);

                if (!heroes.ContainsKey(name))
                {
                    heroes.Add(name, new List<int> { hp, mp });
                }
            }


            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "CastSpell")
                {
                    string heroName = command[1];
                    int mpNeeded = int.Parse(command[2]);
                    string spellName = command[3];

                    if (heroes[heroName][1] >= mpNeeded)
                    {
                        heroes[heroName][1] -= mpNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName][1] } MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }

                else if (command[0] == "TakeDamage")
                {
                    string heroName = command[1];
                    int damage = int.Parse(command[2]);
                    string attacker = command[3];

                    heroes[heroName][0] -= damage;

                    if (heroes[heroName][0] > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName][0]} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        heroes.Remove(heroName);
                    }
                }

                else if (command[0] == "Recharge")
                {
                    string heroName = command[1];
                    int amount = int.Parse(command[2]);

                    Recharge(heroes: heroes, heroName: heroName, amount: amount);

                }

                else if (command[0] == "Heal")
                {
                    string heroName = command[1];
                    int amount = int.Parse(command[2]);

                    Heal(heroes: heroes, heroName: heroName, amount: amount);
                }
            }

            var sorted = heroes.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key).ToList();

            foreach (var hero in sorted)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value[0]}");
                Console.WriteLine($"  MP: {hero.Value[1]}");
            }
        }

        private static void Recharge(Dictionary<string, List<int>> heroes, string heroName, int amount)
        {
            if (heroes[heroName][1] + amount > 200)
            {
                Console.WriteLine($"{heroName} recharged for {200 - heroes[heroName][1]} MP!");
                heroes[heroName][1] = 200;
                return;
            }

            heroes[heroName][1] += amount;
            Console.WriteLine($"{heroName} recharged for {amount} MP!");
        }

        private static void Heal(Dictionary<string, List<int>> heroes, string heroName, int amount)
        {
            if (heroes[heroName][0] + amount > 100)
            {
                Console.WriteLine($"{heroName} healed for {100 - heroes[heroName][0]} HP!");
                heroes[heroName][0] = 100;
                return;
            }

            heroes[heroName][0] += amount;

            Console.WriteLine($"{heroName} healed for {amount} HP!");
        }
    }
}
