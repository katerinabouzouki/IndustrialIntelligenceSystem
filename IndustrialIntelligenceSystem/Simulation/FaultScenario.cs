using IndustrialIntelligenceSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialIntelligenceSystem.Simulation
{
    class FaultScenario
    {
        public Valve Valve { get; private set; }
        public int FaultStartTime { get; private set; }
        public int FaultClearTime { get; private set; }

        public FaultScenario(Valve valve, int faultStartTime, int faultClearTime)
        {
            this.Valve = valve;
            this.FaultStartTime = faultStartTime;
            this.FaultClearTime = faultClearTime;
        }

        public void Evaluate(int currentTime)
        {
            if (currentTime == FaultStartTime)
            {
                Valve.SetFault();
            }
            
            if (currentTime == FaultClearTime)
            {
                Valve.ClearFault();
            }
        }
    }
}
