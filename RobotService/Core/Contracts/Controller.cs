using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Core.Contracts
{

    public class Controller : IController
    {
        private List<string> robotsTypes = new List<string>() { "HouseholdRobot", "PetRobot", "WalkerRobot" };

        private IGarage garage;
        private Charge charge;
        private Chip chip;
        private Polish polish;
        private Rest rest;
        private TechCheck techCheck;
        private Work work;
        public Controller()
        {
            this.garage = new Garage();

            this.charge = new Charge();
            this.polish = new Polish();
            this.chip = new Chip();
            this.rest = new Rest();
            this.techCheck = new TechCheck();
            this.work = new Work();
        }

        public string Charge(string robotName, int procedureTime)
        {
            string result = "";
            if (!this.garage.Robots.Any(x => x.Key == robotName))
            {
                result = String.Format(ExceptionMessages.InexistingRobot, robotName);
            }
            else
            {
                IRobot currrobot = this.garage.Robots.First(x => x.Key == robotName).Value;


                try
                {
                    this.charge.DoService(currrobot, procedureTime);
                    result = String.Format(OutputMessages.ChargeProcedure, robotName);
                }
                catch (Exception m)
                {
                    result = m.Message;
                }
            }
            return result;


        }

        public string Chip(string robotName, int procedureTime)
        {
            string result = "";
            if (!this.garage.Robots.Any(x => x.Key == robotName))
            {
                result = String.Format(ExceptionMessages.InexistingRobot, robotName);
            }
            else
            {
                IRobot currrobot = this.garage.Robots.First(x => x.Key == robotName).Value;


                try
                {
                    this.chip.DoService(currrobot, procedureTime);
                    result = String.Format(OutputMessages.ChipProcedure, robotName);
                }
                catch (Exception m)
                {
                    result = m.Message;
                }
            }
            return result;
        }

        public string History(string procedureType)
        {
            string result = "";
            switch (procedureType)
            {
                case "Charge":
                    result = this.charge.History();
                    break;
                case "Chip":
                    result = this.chip.History();
                    break;
                case "Polish":
                    result = this.polish.History();
                    break;
                case "Rest":
                    result = this.rest.History();
                    break;
                case "TechCheck":
                    result = this.techCheck.History();
                    break;
                case "Work":
                    result = this.work.History();
                    break;
            }
            return result;
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            string result = "";
            if (!robotsTypes.Contains(robotType))
            {
                result = String.Format(ExceptionMessages.InvalidRobotType, robotType);

            }
            else
            {
                try
                {
                    IRobot robot = null;
                    switch (robotType)
                    {
                        case "HouseholdRobot":
                            robot = new HouseholdRobot(name, energy, happiness, procedureTime);
                            break;
                        case "PetRobot":
                            robot = new PetRobot(name, energy, happiness, procedureTime);
                            break;
                        case "WalkerRobot":
                            robot = new WalkerRobot(name, energy, happiness, procedureTime);
                            break;
                    }

                    this.garage.Manufacture(robot);
                    result = String.Format(OutputMessages.RobotManufactured, name);
                }
                catch (Exception message)
                {

                    result = message.Message;
                }
            }

            return result;
        }

        public string Polish(string robotName, int procedureTime)
        {
            string result = "";
            if (!this.garage.Robots.Any(x => x.Key == robotName))
            {
                result = String.Format(ExceptionMessages.InexistingRobot, robotName);
            }
            else
            {
                IRobot currrobot = this.garage.Robots.First(x => x.Key == robotName).Value;

                try
                {
                    this.polish.DoService(currrobot, procedureTime);
                    // {current robot name} was working for {procedure time} hours"
                    result = String.Format(OutputMessages.PolishProcedure, robotName);
                }
                catch (Exception m)
                {
                    result = m.Message;
                }
            }
            return result;



        }

        public string Rest(string robotName, int procedureTime)
        {
            string result = "";
            if (!this.garage.Robots.Any(x => x.Key == robotName))
            {
                result = String.Format(ExceptionMessages.InexistingRobot, robotName);
            }
            else
            {
                IRobot currrobot = this.garage.Robots.First(x => x.Key == robotName).Value;

                try
                {
                    this.rest.DoService(currrobot, procedureTime);
                    // {current robot name} was working for {procedure time} hours"
                    result = String.Format(OutputMessages.RestProcedure, robotName);
                }
                catch (Exception m)
                {
                    result = m.Message;
                }
            }
            return result;

        }



        public string Sell(string robotName, string ownerName)
        {
            string result = "";
            //if (!this.garage.Robots.Any(x => x.Key == robotName))
            //{
            //    result = String.Format(ExceptionMessages.InexistingRobot, robotName);
            //} i bez taq moje zashoto si go prawi i bez tuj samiq metod sell w garajeto
            //else
           // {
                IRobot currrobot = this.garage.Robots.First(x => x.Key == robotName).Value;
                this.garage.Sell(robotName, ownerName);
                if(currrobot.IsChipped)
                {
                    result = String.Format(OutputMessages.SellChippedRobot, ownerName);
                }
                else
                {
                    result = String.Format( OutputMessages.SellNotChippedRobot, ownerName);
                }
             
          //  }
            return result;

        }

        public string TechCheck(string robotName, int procedureTime)
        {
            string result = "";
            if (!this.garage.Robots.Any(x => x.Key == robotName))
            {
                result = String.Format( ExceptionMessages.InexistingRobot, robotName);
            }
            else
            {
                IRobot currrobot = this.garage.Robots.First(x => x.Key == robotName).Value;

                try
                {
                    this.techCheck.DoService(currrobot, procedureTime);
                    // {current robot name} was working for {procedure time} hours"
                    result = String.Format( OutputMessages.TechCheckProcedure, robotName);
                }
                catch (Exception m)
                {
                    result = m.Message;
                }
            }
            return result;
        }

        public string Work(string robotName, int procedureTime)
        {

            string result = "";
            if (!this.garage.Robots.Any(x => x.Key == robotName))
            {
                result = String.Format(ExceptionMessages.InexistingRobot, robotName);
            }
            else
            {
                IRobot currrobot = this.garage.Robots.First(x => x.Key == robotName).Value;

                try
                {
                    this.work.DoService(currrobot, procedureTime);
                    // {current robot name} was working for {procedure time} hours"
                    result = String.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
                }
                catch (Exception m)
                {
                    result = m.Message;
                }
            }
            return result;
        }
    }
}
