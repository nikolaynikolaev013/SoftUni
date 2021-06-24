using System;
using System.Collections.Generic;

namespace _04.Wild_Farm.Models.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const string DefaultMouseSound = "Squeak";
        private const double DefaultWeightGainForKG = 0.10;


        private List<string> defaultFavFood = new List<string>() { "Vegetable", "Fruit" };

        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string Sound => DefaultMouseSound;

        public override List<string> FavFood => this.defaultFavFood;

        public override double WeightGainForKG => DefaultWeightGainForKG;
    }
}
