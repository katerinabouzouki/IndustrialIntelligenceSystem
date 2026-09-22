using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialIntelligenceSystem.Models
{
    class Valve
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public bool IsOpen { get; private set; }
        public double MaxFlowRate { get; private set; }
        public bool IsFaulted { get; private set; }

        public Valve(int id, string name, double maxFlowRate)
        {
            this.Id = id;
            this.Name = name;
            this.MaxFlowRate = maxFlowRate;
            this.IsOpen = false;
            this.IsFaulted = false;
        }

        public void Open()
        {
            if (!IsFaulted)
            {
                IsOpen = true;
            }
        }

        public void Close()
        {
            IsOpen = false;
        }

        public void SetFault()
        {
            IsFaulted = true;
        }

        public void ClearFault()
        {
            IsFaulted = false;
        }
    }
}
