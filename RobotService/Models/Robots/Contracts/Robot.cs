using System;

namespace RobotService.Models.Robots.Contracts
{
    public abstract class Robot : IRobot
    {
        private const string defaultOwner = "Service";
        private int hapiness;
        private int energy;
        protected Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
            this.Owner = defaultOwner;
            this.IsBought = false;
            this.IsChipped = false;
            this.IsChecked = false;
        }
        public string Name { get; private set; }

        public int Happiness
        {
            get { return this.hapiness; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    this.hapiness = value;
                }
                else
                {
                    throw new ArgumentException("Invalid happiness");

                }

            }
        }

        public int Energy
        {
            get { return this.energy; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    this.energy = value;
                }
                else
                {
                    throw new ArgumentException("Invalid energy");
                }
                
            }

        }
        public int ProcedureTime { get; set; }
        public string Owner { get; set; }
        
        public bool IsBought { get; set; }
         
        public bool IsChipped { get; set; }
        public bool IsChecked { get; set; }

          public override string ToString()
        {
            return $" Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    

    }
}
