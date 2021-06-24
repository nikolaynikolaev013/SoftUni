using System;
using System.Collections.Generic;

namespace _04.Pizza_Calorie
{
    public class Dough
    {

        private const double MinGrams = 0;
        private const double MaxGrams = 200;

        private const double BaseCaloriesPerGram = 2;

        private readonly Dictionary<string, double> flourTypes = new Dictionary<string, double>(){
            { "white" , 1.5},
            { "wholegrain", 1.0}
        };

        private readonly Dictionary<string, double> bakingTechniques = new Dictionary<string, double>()
        {
            { "crispy", 0.9},
            { "chewy", 1.1},
            { "homemade", 1.0}
        };


        private string flourType;
        private string bakingTechnique;
        private double grams;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (!this.flourTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (!this.bakingTechniques.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }

        public double Grams
        {
            get => this.grams;
            private set
            {
                if (value < MinGrams || value > MaxGrams)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinGrams}..{MaxGrams}].");
                }
                this.grams = value;

            }
        }

        public double CaloriesPerGram => BaseCaloriesPerGram * this.flourTypes[this.flourType.ToLower()] * this.bakingTechniques[this.BakingTechnique.ToLower()];

        public double TotalCalories => this.Grams * this.CaloriesPerGram;
    }
}
