using System;
using System.Collections.Generic;

namespace _04.Wild_Farm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const string DefaultHenSound = "Cluck";
        private const double DefaultWeightGainForKG = 0.35;

        private  List<string> defaultFavFood = new List<string> { "Vegetable", "Fruit", "Meat", "Seeds" };

        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string Sound => DefaultHenSound;

        public override List<string> FavFood => defaultFavFood;

        public override double WeightGainForKG => DefaultWeightGainForKG;
    }
}
