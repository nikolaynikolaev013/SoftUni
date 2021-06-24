using System;
using System.Collections.Generic;

namespace _04.Wild_Farm.Models.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const string DefaultCatSound = "Meow";
        private const double DefaultWeightGainForKG = 0.30;

        private List<string> defaultFavFood = new List<string>() { "Vegetable", "Meat" };

        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string Sound => DefaultCatSound;

        public override List<string> FavFood => this.defaultFavFood;

        public override double WeightGainForKG => DefaultWeightGainForKG;
    }
}
