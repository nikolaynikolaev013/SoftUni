using System;
namespace _01.Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double acConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity, bool isACOn = true) : base(fuelQuantity, fuelConsumption, tankCapacity, isACOn)
        {
        }

        public override double ACConsumption => acConsumption;
    }
}
