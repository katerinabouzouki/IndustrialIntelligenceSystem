using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialIntelligenceSystem.Interfaces
{
    public interface IFaultable
    {
        bool IsFaulted { get; }

        void SetFault();

        void ClearFault();
    }
}

