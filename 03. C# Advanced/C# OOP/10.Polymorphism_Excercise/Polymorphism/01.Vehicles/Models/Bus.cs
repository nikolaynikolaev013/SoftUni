using System;
namespace _01.Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double acConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity, bool isACOn = true)
            : base(fuelQuantity, fuelConsumption, tankCapacity, isACOn)
        {
        }

        public override double ACConsumption => acConsumption;
    }
}
