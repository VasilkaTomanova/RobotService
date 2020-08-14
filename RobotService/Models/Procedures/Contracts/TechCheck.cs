using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures.Contracts
{
  public class TechCheck : Procedure
    {
        public TechCheck()
        : base()
        {

        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Energy -= 8;

            if (robot.IsChecked == false)
            {
                robot.IsChecked = true;
            }
            else
            {
                robot.Energy -= 8;
            }
          
          
        }
    }
}
