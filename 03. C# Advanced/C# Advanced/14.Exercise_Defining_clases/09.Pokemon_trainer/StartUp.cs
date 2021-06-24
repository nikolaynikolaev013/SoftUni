using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            var trainers = new Dictionary<string, Trainer>();
            TrainersFill(trainers);
            ManageBadges(trainers);


            Console.WriteLine(String.Join(Environment.NewLine, trainers.Values.OrderByDescending(x=>x.numOfBadges)));
        }

        private static void ManageBadges(Dictionary<string, Trainer> trainers)
        {
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    bool hasOne = trainer.Value.Pokemons.Any(x => x.Element == input);

                    if (hasOne)
                    {
                        trainer.Value.numOfBadges++;
                    }
                    else
                    {
                        trainer.Value.ReduceHealth();
                    }
                }
            }
        }

        private static void TrainersFill(Dictionary<string, Trainer> trainers)
        {
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                var command = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
                var trainerName = command[0];
                var pokemonName = command[1];
                var pokemonElement = command[2];
                var pokemonHealth = int.Parse(command[3]);

                Pokemon pokemon = CreatePokemon(pokemonName, pokemonElement, pokemonHealth);

                if (trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName].Pokemons.Add(pokemon);
                }
                else
                {
                    trainers.Add(trainerName, new Trainer(trainerName, pokemon));
                }
            }
        }

        static Pokemon CreatePokemon(string pokemonName, string pokemonElement, int pokemonHealth)
        {
            return new Pokemon(pokemonName, pokemonElement, pokemonHealth);
        }
    }
}
