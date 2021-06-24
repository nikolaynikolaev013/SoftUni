using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Core.Contracts
{
    public class ChampionshipController : IChampionshipController
    {
        private const int MinimumRaceDrivers = 3;

        private IRepository<ICar> carRepository;
        private IRepository<IDriver> driverRepository;
        private IRepository<IRace> raceRepository;

        public ChampionshipController()
        {
            this.carRepository = new CarRepository();
            this.driverRepository = new DriverRepository();
            this.raceRepository = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (this.driverRepository.GetByName(driverName) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            else if (this.carRepository.GetByName(carModel) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarNotFound, carModel));
            }

            this.driverRepository.GetByName(driverName).AddCar(this.carRepository.GetByName(carModel));

            return String.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (this.raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (this.driverRepository.GetByName(driverName)==null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            this.raceRepository.GetByName(raceName).AddDriver(this.driverRepository.GetByName(driverName));

            return String.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            Enum.TryParse(type, out CarTypes typeEnum);
            ICar car = null;

            switch (typeEnum)
            {
                case CarTypes.Muscle:
                    car = new MuscleCar(model, horsePower);
                    break;
                case CarTypes.Sports:
                    car = new SportsCar(model, horsePower);
                    break;
            }

            if (this.carRepository.GetByName(model) != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CarExists, model));
            }

            this.carRepository.Add(car);
            return String.Format(OutputMessages.CarCreated, car.GetType().Name, car.Model);
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);

            if (this.driverRepository.GetByName(driverName) != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DriversExists, driverName));
            }

            this.driverRepository.Add(driver);
            return String.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);

            this.raceRepository.Add(race);

            return String.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < MinimumRaceDrivers)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, MinimumRaceDrivers));
            }

            List<IDriver> bestThree = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Driver {bestThree[0].Name} wins {race.Name} race.");
            sb.AppendLine($"Driver {bestThree[1].Name} is second in {race.Name} race.");
            sb.AppendLine($"Driver {bestThree[2].Name} is third in {race.Name} race.");

            return sb.ToString().TrimEnd();

        }
    }
}
