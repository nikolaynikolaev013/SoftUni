using System;
using System.Collections.Generic;

namespace _04.Wild_Farm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        private const string DefaultOwlSound = "Hoot Hoot";
        private const double DefaultWeightGainForKG = 0.25;

        private List<string> defaultFavFood = new List<string>{ "Meat" };

        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string Sound => DefaultOwlSound;

        public override List<string> FavFood => this.defaultFavFood;

        public override double WeightGainForKG => DefaultWeightGainForKG;
    }
}
