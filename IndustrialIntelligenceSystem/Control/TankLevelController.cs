using System;
using System.Collections.Generic;
using System.Text;
using IndustrialIntelligenceSystem.Models;
using IndustrialIntelligenceSystem.Sensors;

namespace IndustrialIntelligenceSystem.Control
{
    class TankLevelController
    {
        public LevelSensor LevelSensor { get; private set; }
        public Valve Valve { get; private set; }
        public double LowThreshold { get; private set; }
        public double HighThreshold { get; private set; }

        public TankLevelController(
            LevelSensor levelSensor, 
            Valve valve, 
            double lowThreshold, 
            double highThreshold)
        {
            this.LevelSensor = levelSensor;
            this.Valve = valve;
            this.LowThreshold = lowThreshold;
            this.HighThreshold = highThreshold;
        }

        public void Evaluate()
        {
            if (LevelSensor.CurrentValue < LowThreshold
                && !Valve.IsOpen)
            {
                Valve.Open();
            }
            else if (LevelSensor.CurrentValue >= HighThreshold
                && Valve.IsOpen)
            {
                Valve.Close();
            }
        }
    }
}
