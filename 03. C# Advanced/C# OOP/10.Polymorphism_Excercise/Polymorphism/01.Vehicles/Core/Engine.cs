using System;
using System.Linq;
using _01.Vehicles.Factories;
using _01.Vehicles.IO;
using _01.Vehicles.Models;

namespace _01.Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }

        public void Run()
        {
            var carArgs = reader.CustomReader()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            IVehicle car = CreateVehicle(carArgs);

            var truckArgs = reader.CustomReader()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            IVehicle truck = CreateVehicle(truckArgs);

            var busArgs = reader.CustomReader()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            IVehicle bus = CreateVehicle(busArgs);

            var n = int.Parse(reader.CustomReader());

            for (int i = 0; i < n; i++)
            {
                var input = reader.CustomReader()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var command = input[0];
                var type = input[1];
                var param = double.Parse(input[2]);

                if (command == "Drive")
                {
                    Drive(car, truck, bus, type, param);
                }
                else if (command == "DriveEmpty")
                {
                    bus.StopAC();
                    DriveEmpty(bus, param);
                }
                else if (command == "Refuel")
                {
                    Refuel(car, truck, bus, type, param);
                }
            }

            writer.CustomWriter(car.ToString());
            writer.CustomWriter(truck.ToString());
            writer.CustomWriter(bus.ToString());

        }

        private void Refuel(IVehicle car, IVehicle truck, IVehicle bus, string type, double param)
        {
            try
            {
                if (type == nameof(Car))
                {
                    car.Refuel(param);
                }
                else if (type == nameof(Truck))
                {
                    truck.Refuel(param);
                }
                else if (type == nameof(Bus))
                {
                    bus.Refuel(param);
                }
            }
            catch (Exception ex)
            {
                this.writer.CustomWriter(ex.Message);
            }
        }

        private void DriveEmpty(IVehicle bus, double param)
        {
            bus.StopAC();
            bool isDrive = bus.Drive(param);
            

            if (isDrive)
            {
                writer.CustomWriter($"Bus travelled {param} km");
            }
            else
            {
                writer.CustomWriter($"Bus needs refueling");
            }
        }

        private void Drive(IVehicle car, IVehicle truck, IVehicle bus, string type, double param)
        {
            bool isDrive = false;

            if (type == nameof(Car))
            {
                isDrive = car.Drive(param);
            }
            else if (type == nameof(Truck))
            {
                isDrive = truck.Drive(param);
            }
            else if (type == nameof(Bus))
            {
                bus.StartAC();
                isDrive = bus.Drive(param);
            }

            if (isDrive)
            {
                writer.CustomWriter($"{type} travelled {param} km");
            }
            else
            {
                writer.CustomWriter($"{type} needs refueling");
            }
        }

        private IVehicle CreateVehicle(string[] args)
        {
            var type = args[0];
            var fuelQuantity = double.Parse(args[1]);
            var fuelConsumption = double.Parse(args[2]);
            var tankCapacity = double.Parse(args[3]);

            IVehicle vehicle = vehicleFactory.CreateVehicle(type, fuelQuantity, fuelConsumption, tankCapacity, true);
            return vehicle;
        }
    }
}
