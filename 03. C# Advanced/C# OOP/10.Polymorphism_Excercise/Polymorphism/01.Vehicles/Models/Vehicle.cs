using System;
using _01.Vehicles.Utilities;

namespace _01.Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private const double DefaultFuelQuantity = 0;

        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, bool isACOn = true)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.IsACOn = isACOn;
        }
        public double FuelQuantity { get => this.fuelQuantity;
            private set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = DefaultFuelQuantity;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption { get; private set; }

        public bool IsACOn { get; private set; }

        public abstract double ACConsumption { get; }

        public double TankCapacity { get; private set; }



        public bool Drive(double distance)
        {
            var usedFuel = distance * FuelConsumption;

            if (IsACOn)
            {
                usedFuel += distance * ACConsumption;
            }

            if (usedFuel <= FuelQuantity)
            {
                FuelQuantity -= usedFuel;
                return true;
            }

            return false;
        }

        public virtual void Refuel(double liters)
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
            FuelQuantity += liters;
        }

        public void StartAC()
        {
            this.IsACOn = true;
        }

        public void StopAC()
        {
            this.IsACOn = false;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
