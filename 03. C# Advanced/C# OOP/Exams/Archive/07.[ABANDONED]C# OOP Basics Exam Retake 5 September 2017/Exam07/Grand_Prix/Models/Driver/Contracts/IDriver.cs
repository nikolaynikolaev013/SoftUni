using System;
using Grand_Prix.Models.Car.Contracts;

namespace Grand_Prix.Models.Drivers.Contracts
{
    public interface IDriver
    {
        public string Name { get; }
        public float TotalTime { get; }
        public ICar Car { get; }
        public float FuelConsumptionPerKm { get; }
        public float Speed { get; }
    }
}
