using System;
using System.Collections.Generic;
using System.Text;
using IndustrialIntelligenceSystem.Sensors;

namespace IndustrialIntelligenceSystem.Alarms
{
    class LowLevelAlarm : Alarm
    {
        public LevelSensor LevelSensor { get; private set; }
        public double Threshold { get; private set; }

        public LowLevelAlarm(string name, string message, AlarmSeverity severity, LevelSensor levelSensor, double threshold) : base(name, message, severity)
        {
            this.LevelSensor = levelSensor;
            this.Threshold = threshold;
        }

        public void Evaluate()
        {
            if ((LevelSensor.CurrentValue < Threshold)
                && !IsActive)
            {
                Activate();
            }
            else if ((LevelSensor.CurrentValue >= Threshold)
                    && IsActive)
            {
                Deactivate();
            }
        }
    }
}
