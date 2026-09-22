using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialIntelligenceSystem.Models
{
    class Pump
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public double MaxFlowRate { get; private set; }
        public bool IsRunning { get; private set; }
        public double CurrentFlowRate { get; private set; }
        public double FlowRateSetpoint { get; private set; }

        public Pump(int id, string name, double maxFlowRate)
        {
            this.Id = id;
            this.Name = name;

            if (maxFlowRate <= 0)
            {
                throw new ArgumentException("Max flow rate must be greater than zero.");
            }

            this.MaxFlowRate = maxFlowRate;

            this.IsRunning = false;

            this.CurrentFlowRate = 0;

            this.FlowRateSetpoint = 0;
        }

        public void Start()
        {
            IsRunning = true;
            CurrentFlowRate = FlowRateSetpoint;
        }

        public void Stop()
        {
            IsRunning = false;
            CurrentFlowRate = 0;
        }

        public void SetFlowRate(double flowRate)
        {
            if (!IsRunning)
            {
                throw new InvalidOperationException("Cannot set flow rate while pump is stopped.");
            }
            else if (flowRate <= 0)
            {
                throw new ArgumentException("Flow rate must be more than zero.");
            }
            else if (flowRate > MaxFlowRate)
            {
                throw new ArgumentException("Flow rate must not exceed max flow rate.");
            }
            else
            {
                FlowRateSetpoint = flowRate;
                CurrentFlowRate = flowRate;
            }
        }
    }
}
