using System;
using System.Collections.Generic;
using System.Text;
using IndustrialIntelligenceSystem.Models;


namespace IndustrialIntelligenceSystem.Sensors
{
    class FlowSensor : Sensor
    {
        public Pump Pump { get; private set; }

        public FlowSensor(string id, string name, Pump pump) : base(id, name, "L/min")
        {
            this.Pump = pump;
        }

        public void ReadValue()
        {
            CurrentValue = Pump.CurrentFlowRate;
        }
    }
}
