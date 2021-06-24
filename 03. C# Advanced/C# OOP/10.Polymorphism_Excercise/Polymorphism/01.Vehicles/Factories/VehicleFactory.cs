using System;
using _01.Vehicles.Models;

namespace _01.Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {

        public IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption,double tankCapacity, bool isACOn = true)
        {
            IVehicle vehicle = null;

            if (type == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity, isACOn);
            }
            else if (type == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity, isACOn);
            }
            else if (type == nameof(Bus))
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity, isACOn);
            }

            return vehicle;
        }
    }
}
