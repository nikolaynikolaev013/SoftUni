using System;

namespace exam3
{
    class Program
    {
        static void Main(string[] args)
        {
            string spell = Console.ReadLine();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "For Azeroth")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "GladiatorStance":
                        spell = spell.ToUpper();
                        Console.WriteLine(spell);
                        break;
                    case "DefensiveStance":
                        spell = spell.ToLower();
                        Console.WriteLine(spell);
                        break;
                    case "Dispel":
                        spell = Dispel(spell: spell, command: command);
                        break;
                    case "Target":
                        spell = Target(spell: spell, command: command);
                        break;
                    default:
                        Console.WriteLine("Command doesn't exist!");
                        break;
                }
            }
        }

        private static string Target(string spell, string[] command)
        {
            if (command[1] == "Change")
            {
                string substring = command[2];
                string secondSubstring = command[3];

                if (spell.Contains(substring))
                {
                    spell = spell.Replace(substring, secondSubstring);
                    Console.WriteLine(spell);
                }
            }
            else if (command[1] == "Remove")
            {
                string substring = command[2];

                if (spell.Contains(substring))
                {
                    spell = spell.Remove(spell.IndexOf(substring), substring.Length);
                    Console.WriteLine(spell);
                }
            }
            else
            {
                Console.WriteLine("Command doesn't exist!");
            }

            return spell;
        }

        private static string Dispel(string spell, string[] command)
        {
            int index = int.Parse(command[1]);
            char letter = char.Parse(command[2]);

            if (index >= 0 && index < spell.Length)
            {
                spell = spell.Remove(index, 1);
                spell = spell.Insert(index, letter.ToString());
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Dispel too weak.");
            }

            return spell;
        }
    }
}
