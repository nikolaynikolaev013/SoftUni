using System;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; } = 0;

        public Car()
        {
        }
        public Car(string model, double fuelAmount, double fuelConsumationPerKM)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumationPerKM;
        }

        public void DriveCar(double km)
        {
            if (km * FuelConsumptionPerKilometer <= FuelAmount)
            {
                this.TravelledDistance += km;
                this.FuelAmount -= km * FuelConsumptionPerKilometer;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:F2} {this.TravelledDistance}";
        }
    }
}
