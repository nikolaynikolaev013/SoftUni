using System;
using System.Collections.Generic;
using System.Linq;
using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities;
using RobotService.Utilities.Messages;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage garage;
        private IDictionary<ProcedureTypes, Procedure> procedures;

        public Controller()
        {
            this.garage = new Garage();
            this.procedures = new Dictionary<ProcedureTypes, Procedure>();
            FillUpProcedures();
        }


        public string Charge(string robotName, int procedureTime)
        {
            return DoProcedure(ProcedureTypes.Charge, robotName, procedureTime, String.Format(OutputMessages.ChargeProcedure, robotName));
        }

        public string Chip(string robotName, int procedureTime)
        {
            return DoProcedure(ProcedureTypes.Chip, robotName, procedureTime, String.Format(OutputMessages.ChipProcedure, robotName));
        }

        public string History(string procedureType)
        {
            IProcedure procedure = null;

            Enum.TryParse(procedureType, out ProcedureTypes procedureTypeEnum);

            procedure = this.procedures[procedureTypeEnum];

            return procedure.History();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = null;


            if (!Enum.TryParse(robotType, out RobotTypes robotTypeEnum))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            switch (robotTypeEnum)
            {
                case RobotTypes.HouseholdRobot:
                    robot = new HouseholdRobot(name, energy, happiness, procedureTime);
                    break;
                case RobotTypes.PetRobot:
                    robot = new PetRobot(name, energy, happiness, procedureTime);
                    break;
                case RobotTypes.WalkerRobot:
                    robot = new WalkerRobot(name, energy, happiness, procedureTime);
                    break;
            }

            this.garage.Manufacture(robot);
            return String.Format(OutputMessages.RobotManufactured, name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            return DoProcedure(ProcedureTypes.Polish, robotName, procedureTime, String.Format(OutputMessages.PolishProcedure, robotName));
        }

        public string Rest(string robotName, int procedureTime)
        {
            return DoProcedure(ProcedureTypes.Rest, robotName, procedureTime, String.Format(OutputMessages.RestProcedure, robotName));

        }

        public string Sell(string robotName, string ownerName)
        {
            CheckIfRobotIsAvailable(robotName);
            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;
            this.garage.Sell(robotName, ownerName);
            if (robot.IsChipped)
            {
                return String.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                return String.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            return DoProcedure(ProcedureTypes.TechCheck, robotName, procedureTime, String.Format(OutputMessages.TechCheckProcedure, robotName));
        }

        public string Work(string robotName, int procedureTime)
        {
            return DoProcedure(ProcedureTypes.Work, robotName, procedureTime, String.Format(OutputMessages.WorkProcedure, robotName, procedureTime));
        }

        private void CheckIfRobotIsAvailable(string robotName)
        {
            if (!this.garage.Robots.Any(x => x.Key == robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
        }

        private void FillUpProcedures()
        {
            this.procedures.Add(ProcedureTypes.Chip, new Chip());
            this.procedures.Add(ProcedureTypes.Charge, new Charge());
            this.procedures.Add(ProcedureTypes.Polish, new Polish());
            this.procedures.Add(ProcedureTypes.Rest, new Rest());
            this.procedures.Add(ProcedureTypes.TechCheck, new TechCheck());
            this.procedures.Add(ProcedureTypes.Work, new Work());
        }

        private string DoProcedure(ProcedureTypes type, string robotName, int procedureTime, string outputMessage)
        {
            CheckIfRobotIsAvailable(robotName);
            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;
            this.procedures[type].DoService(robot, procedureTime);
            return outputMessage;
        }

    }
}
