using IndustrialIntelligenceSystem.Models;
using IndustrialIntelligenceSystem.Sensors;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialIntelligenceSystem.Alarms
{
    public enum AlarmSeverity
    {
        Warning,
        Alarm,
        Critical
    }
    class Alarm
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public AlarmSeverity Severity { get; set; }
        public bool IsActive { get; private set; }

        public Alarm(string name, string message, AlarmSeverity severity)
        {
            this.Name = name;
            this.Message = message;
            this.Severity = severity;

            IsActive = false;
        }

        public void Activate()
        {
            IsActive = true;

            Console.WriteLine("⚠ ALARM ACTIVATED");
            Console.WriteLine(Name);
            Console.WriteLine(Message);
            Console.WriteLine(Severity);
        }

        public void Deactivate()
        {
            IsActive = false;

            Console.WriteLine($"ALARM CLEARED: {Name}");
        }
    }
}
