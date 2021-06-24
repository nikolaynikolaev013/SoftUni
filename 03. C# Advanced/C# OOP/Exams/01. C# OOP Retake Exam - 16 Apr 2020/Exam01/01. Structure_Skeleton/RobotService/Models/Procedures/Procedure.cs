using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected IList<IRobot> robots;

        protected Procedure()
        {
            this.robots = new List<IRobot>();
        }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
            robot.ProcedureTime -= procedureTime;
        }

        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);

            foreach (var robot in robots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
