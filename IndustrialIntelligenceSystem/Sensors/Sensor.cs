using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialIntelligenceSystem.Sensors
{
    abstract class Sensor
    {
        public string Id { get; private set; }
        public string Name { get;  set; }
        public string Unit { get; private set; }
        public double CurrentValue { get; protected set; }

        protected Sensor(string id, string name, string unit)
        {
            this.Id = id;
            this.Name = name;
            this.Unit = unit;
            CurrentValue = 0;
        }
    }
}
