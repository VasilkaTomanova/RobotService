using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures.Contracts
{
   public class Chip : Procedure
    {
        private const int maxChip = 1;
        
        public Chip()
            :base()
        {

        }

        

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            if(robot.IsChipped == true)
            {
                throw new ArgumentException($"{robot.Name} is already chipped");
            }
            robot.Happiness -= 5;
            robot.IsChipped = true;


        }


    }
}
