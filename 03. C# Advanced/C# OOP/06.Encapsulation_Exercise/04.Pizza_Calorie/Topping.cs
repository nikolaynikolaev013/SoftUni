using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Pizza_Calorie
{
    public class Topping
    {
        private const double MinWeight = 1;
        private const double MaxWeight = 50;
        private const double BaseCaloriePerGram = 2;


        private readonly Dictionary<string, double> types = new Dictionary<string, double>()
        {
            { "meat", 1.2},
            { "veggies", 0.8},
            { "cheese", 1.1},
            { "sauce", 0.9}
        };

        private string type;
        private double weight;


        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type {
            get => this.type;
            private set {
                if (!this.types.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }

        public double Weight {
            get => this.weight;
            private set {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [{MinWeight}..{MaxWeight}].");
                }
                this.weight = value;
            }
        }

        public double CaloriesPerGram => BaseCaloriePerGram * types[this.Type.ToLower()];
        public double TotalCalories => CaloriesPerGram * this.Weight;
    }
}
