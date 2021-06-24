using System;
using System.Collections.Generic;
using System.Linq;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int Capacity = 10;

        private IDictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots => (IReadOnlyDictionary<string, IRobot>)this.robots;

        public void Manufacture(IRobot robot)
        {
            if (this.Robots.Count >= Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (this.Robots.Any(x=>x.Key == robot.Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }

            this.robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.Robots.Any(x=>x.Key == robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot robot = this.Robots.FirstOrDefault(x => x.Key == robotName).Value;
            robot.Owner = ownerName;
            robot.IsBought = true;
            this.robots.Remove(robotName);
        }
    }
}
