using System;
namespace _01.Vehicles.Models
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        bool IsACOn { get; }
        double ACConsumption { get; }
        double TankCapacity { get; }

        bool Drive(double distance);
        void Refuel(double liters);
        void StartAC();
        void StopAC();
    }
}
