using System;
using _01.Vehicles.Utilities;

namespace _01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double acConsumption = 1.6;
        private const double DefaultFuelCapacityPercentage = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity, bool isACOn = true) : base(fuelQuantity, fuelConsumption, tankCapacity, isACOn)
        {
        }

        public override double ACConsumption => acConsumption;

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException(ExceptionMessages.NegativeFuelAmount);
            }
            else if (this.FuelQuantity + liters > this.TankCapacity)
            {
                string msg = String.Format(ExceptionMessages.InvalidFuelAmount, liters);

                throw new ArgumentException(msg);
            }

            base.Refuel(liters * DefaultFuelCapacityPercentage);
        }
    }
}
