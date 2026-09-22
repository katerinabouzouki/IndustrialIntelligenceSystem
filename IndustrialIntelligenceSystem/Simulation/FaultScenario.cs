using IndustrialIntelligenceSystem.Models;
using IndustrialIntelligenceSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialIntelligenceSystem.Simulation
{
    class FaultScenario
    {
        public IFaultable Component { get; private set; }
        public int FaultStartTime { get; private set; }
        public int FaultClearTime { get; private set; }

        public FaultScenario(IFaultable component, int faultStartTime, int faultClearTime)
        {
            this.Component = component;
            this.FaultStartTime = faultStartTime;
            this.FaultClearTime = faultClearTime;
        }

        public void Evaluate(int currentTime)
        {
            if (currentTime == FaultStartTime)
            {
                Component.SetFault();
            }
            
            if (currentTime == FaultClearTime)
            {
                Component.ClearFault();
            }
        }
    }
}
