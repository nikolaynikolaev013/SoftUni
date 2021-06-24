using System;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars
{
    public abstract class Car : ICar
    {
        private const int MinimumModelLength = 4;

        private string model;
        private int horsePower;

        private int minHorsePower;
        private int maxHorsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => this.model;

            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < MinimumModelLength)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidModel, value, MinimumModelLength));
                }
                this.model = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            private set
            {
                if (value < this.minHorsePower || value > this.maxHorsePower)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }

        //TODO:Check that? 
        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
