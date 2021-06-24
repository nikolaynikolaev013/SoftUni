using System;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private const int DefaultMinimumHappiness = 0;
        private const int DefaultMaximumHappiness = 100;
        private const int DefaultMinimumEnergy = 0;
        private const int DefaultMaximumEnergy = 100;
        private const string DefaultOwner = "Service";

        private int happiness;
        private int energy;

        protected Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.Owner = DefaultOwner;
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
        }

        public string Name { get; private set; }

        public int Happiness
        {
            get => this.happiness;
            set
            {
                if (value < DefaultMinimumHappiness || value > DefaultMaximumHappiness)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }
                this.happiness = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            set
            {
                if (value < DefaultMinimumEnergy || value > DefaultMaximumEnergy)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }
                this.energy = value;
            }
        }

        public int ProcedureTime { get; set; }
        public string Owner { get; set; }
        public bool IsBought { get; set; }
        public bool IsChipped { get; set; }
        public bool IsChecked { get; set; }

        public override string ToString()
        {
            return String.Format(OutputMessages.RobotInfo, this.GetType().Name, this.Name, this.Happiness, this.Energy);
        }
    }
}
