﻿using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures.Contracts
{
   public class Work : Procedure
    {
        public Work()
         : base()
        {

        }
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Energy -= 6;
            robot.Happiness += 12;

        }

    }
}
