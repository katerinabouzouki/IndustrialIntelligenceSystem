using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialIntelligenceSystem.Models
{
    class Pipeline
    {
        public int Id { get; private set; }
        public string Name { get; set; }

        public double LengthMeters { get; private set; }
        public double DiameterMeters { get; private set; }

        public double CurrentPressureBar { get; private set; }
        public double CurrentFlowRate { get; private set; }

        public Pipeline(int id, string name, double lengthMeters, double diameterMeters)
        {
            this.Id = id;
            this.Name = name;

            if (lengthMeters <= 0)
            {
                throw new ArgumentException("Length must be greater than zero.");
            }
            this.LengthMeters = lengthMeters;

            if (diameterMeters <= 0)
            {
                throw new ArgumentException("Diameter must be greater than zero.");
            }
            this.DiameterMeters = diameterMeters;

            CurrentPressureBar = 0.0;
            CurrentFlowRate = 0.0;
        }

        public void UpdateFlow(double flowRate)
        {
            if (flowRate < 0.0)
            {
                throw new ArgumentException("Flow rate must be greter than or equal to zero.");
            }

            CurrentFlowRate = flowRate;
        }

        public void UpdatePressure(double pressure)
        {
            if (pressure < 0.0)
            {
                throw new ArgumentException("Pressure must be greter than or equal to zero.");
            }         
            
            CurrentPressureBar = pressure;
        }
    }
}
