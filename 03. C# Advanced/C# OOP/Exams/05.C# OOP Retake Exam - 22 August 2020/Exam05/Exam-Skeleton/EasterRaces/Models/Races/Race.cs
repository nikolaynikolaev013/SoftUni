using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Races
{
    public class Race : IRace
    {
        private const int MinimumNameLength = 5;
        private const int MinimumNumberOfLaps = 1;

        private string name;
        private int laps;
        private List<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new List<IDriver>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < MinimumNameLength)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidName, value, MinimumNameLength));
                }
                this.name = value;
            }
        }

        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value < MinimumNumberOfLaps)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidNumberOfLaps, MinimumNumberOfLaps));
                }
                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }
            else if (!driver.CanParticipate)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            else if (this.Drivers.Any(x=>x == driver))
            {
                throw new ArgumentNullException(String.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }

            this.drivers.Add(driver);
        }
    }
}
