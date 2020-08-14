using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;

namespace RobotService.Models.Procedures.Contracts
{
    public class Procedure : IProcedure
    {
        protected List<IRobot> robots;
        protected Procedure()
        {
            this.robots = new List<IRobot>();
        }

        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            foreach (Robot robot in this.robots)
            {
                sb.AppendLine(robot.ToString());
            }
            return sb.ToString().TrimEnd();
        }


        public virtual void DoService(IRobot robot, int procedureTime)
        {
          if(robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
            robot.ProcedureTime -= procedureTime;
                this.robots.Add(robot);
        }


    }
}
