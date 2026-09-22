using System;
using System.Collections.Generic;
using System.Text;
using IndustrialIntelligenceSystem.Alarms;
using IndustrialIntelligenceSystem.Models;

namespace IndustrialIntelligenceSystem.Control
{
    class PumpProtectionController
    {
        public LowLevelAlarm LowLevelAlarm { get; private set; }
        public Pump Pump { get; private set; }

        public PumpProtectionController(LowLevelAlarm lowLevelAlarm, Pump pump)
        {
            this.LowLevelAlarm = lowLevelAlarm;
            this.Pump = pump;
        }

        public void Evaluate()
        {
            if (LowLevelAlarm.LevelSensor.CurrentValue < LowLevelAlarm.Threshold 
                    && Pump.IsRunning)
            {
                Pump.Stop();
            }
            else if (LowLevelAlarm.LevelSensor.CurrentValue >= (LowLevelAlarm.Threshold+10) 
                        && !Pump.IsRunning)
            {
                Pump.Start();
            }
        }
    }
}
