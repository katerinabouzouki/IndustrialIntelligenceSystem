using System;
using System.Collections.Generic;
using System.Text;
using IndustrialIntelligenceSystem.Models;

namespace IndustrialIntelligenceSystem.Sensors
{
    class PressureSensor : Sensor
    {
        public Pipeline Pipeline { get; private set; }

        public PressureSensor(string id, string name, Pipeline pipeline) : base(id, name, "bar")
        {
            this.Pipeline = pipeline;
        }
        public void ReadValue()
        {
            CurrentValue = Pipeline.CurrentPressureBar;
        }
    }
}
