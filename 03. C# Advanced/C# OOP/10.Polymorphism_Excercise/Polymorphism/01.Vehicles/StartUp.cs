using System;
using _01.Vehicles.Core;
using _01.Vehicles.Factories;
using _01.Vehicles.IO;

namespace _01.Vehicles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
            IVehicleFactory vehicleFactory = new VehicleFactory();
            Engine engine = new Engine(reader, writer, vehicleFactory);

            engine.Run();
        }

    }
}