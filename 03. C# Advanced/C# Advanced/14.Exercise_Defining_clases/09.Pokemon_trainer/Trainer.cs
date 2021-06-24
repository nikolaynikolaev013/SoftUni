using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Trainer
    {
        public Trainer(string name, Pokemon pokemon)
        {
            this.Name = name;
            Pokemons.Add(pokemon);
        }

        public string Name { get; set; }
        public int numOfBadges { get; set; } = 0;
        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();


        public void ReduceHealth()
        {

            for (int i = 0; i < Pokemons.Count; i++)
            {
                Pokemons[i].Health -= 10;

                if (Pokemons[i].Health <= 0)
                {
                    Pokemons.Remove(Pokemons[i]);
                    i--;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.numOfBadges} {this.Pokemons.Count}";
        }
    }
}
