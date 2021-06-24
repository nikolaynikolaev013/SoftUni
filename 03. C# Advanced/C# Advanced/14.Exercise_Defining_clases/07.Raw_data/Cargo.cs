using System;
namespace DefiningClasses
{
    public class Cargo
    {
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }


        public Cargo()
        {
        }

        public Cargo(int weight, string type)
        {
            this.CargoWeight = weight;
            this.CargoType = type;

        }
    }
}
