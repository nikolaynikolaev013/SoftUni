using System;
using System.Collections.Generic;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System.Linq;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int Capacity = 10;

        private readonly Dictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;


        public void Manufacture(IRobot robot)
        {
            if (this.Robots.Count >= Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (this.Robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }

            robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot robot = Robots.FirstOrDefault(x => x.Key == robotName).Value;

            robot.Owner = ownerName;
            robot.IsBought = true;
            this.robots.Remove(robot.Name);
        }
    }
}
