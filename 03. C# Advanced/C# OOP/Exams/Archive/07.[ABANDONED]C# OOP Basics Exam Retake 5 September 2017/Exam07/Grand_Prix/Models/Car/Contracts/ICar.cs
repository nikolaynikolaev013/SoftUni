using System;
using Grand_Prix.Models.Tyre.Contracts;

namespace Grand_Prix.Models.Car.Contracts
{
    public interface ICar
    {
        public int Hp { get; }
        public float FuelAmount { get; }
        public ITyre Tyre { get; }
    }
}
