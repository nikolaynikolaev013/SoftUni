using System;
using _01.Vehicles.Models;

namespace _01.Vehicles.Factories
{
    public interface IVehicleFactory
    {
        IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption,double tankCapacity, bool isACOn = true);
    }
}
