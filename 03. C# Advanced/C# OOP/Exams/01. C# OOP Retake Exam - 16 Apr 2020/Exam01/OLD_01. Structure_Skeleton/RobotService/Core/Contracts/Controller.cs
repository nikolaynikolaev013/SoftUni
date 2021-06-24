using System;
using System.Collections.Generic;
using System.Linq;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Enums;
using RobotService.Utilities.Messages;

namespace RobotService.Core.Contracts
{
    public class Controller : IController
    {
        private IGarage garage;
        private IDictionary<ProcedureTypes, IProcedure> procedures;

        public Controller()
        {
            garage = new Garage();
            procedures = new Dictionary<ProcedureTypes, IProcedure>();
            FillUpProcedures();
        }

        public string Charge(string robotName, int procedureTime)
        {
            IRobot robot = ValidateRobot(robotName);
            return DoProcedure(robot,
                procedureTime,
                ProcedureTypes.Charge,
                String.Format(OutputMessages.ChargeProcedure, robot.Name));
        }

        public string Chip(string robotName, int procedureTime)
        {
            IRobot robot = ValidateRobot(robotName);
            return DoProcedure(robot,
                procedureTime,
                ProcedureTypes.Chip, 
                String.Format(OutputMessages.ChipProcedure, robot.Name));
        }

        public string History(string procedureType)
        {
            Enum.TryParse(procedureType, out ProcedureTypes ProcedureTypeEnum);

            IProcedure procedure = this.procedures[ProcedureTypeEnum];

            return procedure.History().TrimEnd();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            if (!Enum.TryParse(robotType, out RobotTypes robotTypeEnum))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            IRobot robot = null;

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

            return String.Format(OutputMessages.RobotManufactured, robot.Name);

        }

        public string Polish(string robotName, int procedureTime)
        {
            IRobot robot = ValidateRobot(robotName);
            return DoProcedure(robot,
                procedureTime,
                ProcedureTypes.Polish,
                String.Format(OutputMessages.PolishProcedure, robot.Name));
        }

        public string Rest(string robotName, int procedureTime)
        {
            IRobot robot = ValidateRobot(robotName);
            return DoProcedure(robot,
                procedureTime,
                ProcedureTypes.Rest,
                String.Format(OutputMessages.RestProcedure, robot.Name));
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot robot = garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;

            this.garage.Sell(robotName, ownerName);

            string msg = robot.IsChipped ? String.Format(OutputMessages.SellChippedRobot, ownerName) :
                String.Format(OutputMessages.SellNotChippedRobot, ownerName);

            return msg;
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            IRobot robot = ValidateRobot(robotName);
            return DoProcedure(robot,
                procedureTime,
                ProcedureTypes.TechCheck,
                String.Format(OutputMessages.TechCheckProcedure, robot.Name));
        }

        public string Work(string robotName, int procedureTime)
        {
            IRobot robot = ValidateRobot(robotName);
            return DoProcedure(robot,
                procedureTime,
                ProcedureTypes.Work,
                String.Format(OutputMessages.WorkProcedure, robot.Name, procedureTime));
        }

        private void FillUpProcedures()
        {
            procedures.Add(ProcedureTypes.Charge, new Charge());
            procedures.Add(ProcedureTypes.Chip, new Chip());
            procedures.Add(ProcedureTypes.Polish, new Polish());
            procedures.Add(ProcedureTypes.Rest, new Rest());
            procedures.Add(ProcedureTypes.TechCheck, new TechCheck());
            procedures.Add(ProcedureTypes.Work, new Work());

        }

        private IRobot ValidateRobot(string robotName)
        {
            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;

            if (robot == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            return robot;
        }

        private string DoProcedure(IRobot robot, int procedureTime, ProcedureTypes procedureToDo, string outputMessage)
        {
            IProcedure procedure = procedures[procedureToDo];
            procedure.DoService(robot, procedureTime);
            return outputMessage;
        }
    }
}
