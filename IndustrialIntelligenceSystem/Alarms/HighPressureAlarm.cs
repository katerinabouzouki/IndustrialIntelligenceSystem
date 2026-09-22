using IndustrialIntelligenceSystem.Sensors;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialIntelligenceSystem.Alarms
{
    class HighPressureAlarm : Alarm
    {
        public PressureSensor PressureSensor { get; private set; }
        public double Threshold { get; private set; }

        public HighPressureAlarm(string name, string message, AlarmSeverity severity, PressureSensor pressureSensor, double threshold) : base(name, message, severity)
        {
            this.PressureSensor = pressureSensor;
            this.Threshold = threshold;
        }

        public void Evaluate()
        {
            if ((PressureSensor.CurrentValue > Threshold)
                && !IsActive)
            {
                Activate();
            }
            else if ((PressureSensor.CurrentValue <= Threshold)
                        && IsActive)
            {
                Deactivate();
            }
        }
    }
}
