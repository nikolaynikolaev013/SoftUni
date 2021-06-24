using System;
using Grand_Prix.Models.Car.Contracts;
using Grand_Prix.Models.Drivers.Contracts;

namespace Grand_Prix.Models.Drivers
{
    public abstract class Driver : IDriver
    {
        protected Driver()
        {
        }

        public string Name => throw new NotImplementedException();

        public float TotalTime => throw new NotImplementedException();

        public ICar Car => throw new NotImplementedException();

        public float FuelConsumptionPerKm => throw new NotImplementedException();

        public abstract float Speed { get; }
    }
}
