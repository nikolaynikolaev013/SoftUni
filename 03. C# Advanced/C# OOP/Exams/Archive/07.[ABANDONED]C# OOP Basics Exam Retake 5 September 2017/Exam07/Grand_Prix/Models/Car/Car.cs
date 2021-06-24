using System;
using Grand_Prix.Models.Car.Contracts;
using Grand_Prix.Models.Tyre.Contracts;

namespace Grand_Prix.Models.Car
{
    public abstract class Car : ICar
    {
        private const float DefaultMaximumFuelCapacity = 160;

        private float fuelAmount;

        protected Car()
        {
        }

        public int Hp => throw new NotImplementedException();

        public float FuelAmount
        {
            get => this.fuelAmount;
            set
            {
                if (value > DefaultMaximumFuelCapacity)
                {
                    this.fuelAmount = DefaultMaximumFuelCapacity;
                }
                else if (value < 0)
                {
                    throw new ArgumentException();
                }
                else
                {
                    this.fuelAmount = value;
                }
            }
        }

        public ITyre Tyre { get; private set; }
    }
}
