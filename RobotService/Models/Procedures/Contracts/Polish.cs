﻿using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures.Contracts
{
  public  class Polish : Procedure
    {
        public Polish()
          : base()
        {

        }



        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Happiness -= 7;
        }

    }
}
