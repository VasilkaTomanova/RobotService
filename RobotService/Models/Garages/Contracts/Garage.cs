using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace RobotService.Models.Garages.Contracts
{
    public class Garage : IGarage
    {

        private const int maxCapacity = 10;
        private Dictionary<string, IRobot> r;
        public Garage()
        {
            this.r = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots => r;

        public void Manufacture(IRobot robot)
        {
          
            if(this.r.Count == maxCapacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }
            string robotNameToLookFor = robot.Name;
            if(this.r.Any(x=>x.Key == robotNameToLookFor))
            {
                throw new ArgumentException($"Robot {robotNameToLookFor} already exist");
            }
            this.r[robotNameToLookFor] = robot;

        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.r.Any(x => x.Key == robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }

            KeyValuePair<string,IRobot> kvp= this.r.First(x => x.Key == robotName);
            IRobot robotToSell = kvp.Value;
            robotToSell.Owner = ownerName;
            robotToSell.IsBought = true;
           this.r = this.r
                 .Where(x => x.Key != robotName).ToDictionary(a=>a.Key,b=>b.Value);
        }
    }
}
