using System;
using System.Collections.Generic;

namespace _04.Wild_Farm.Models.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const string DefaultTigerSound = "ROAR!!!";
        private const double DefaultWeightGainForKG = 1;

        private List<string> defaultFavFood = new List<string>() { "Meat" };

        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string Sound => DefaultTigerSound;

        public override List<string> FavFood => this.defaultFavFood;

        public override double WeightGainForKG => DefaultWeightGainForKG;
    }
}
