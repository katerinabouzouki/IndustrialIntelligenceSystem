using IndustrialIntelligenceSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialIntelligenceSystem.Simulation
{
    class WaterNetworkSimulator
    {
        public Tank SourceTank { get; private set; }
        public Pump Pump { get; private set; }
        public Pipeline Pipeline { get; private set; }
        public Valve Valve { get; private set; }
        public Valve InletValve { get; private set; }

        public WaterNetworkSimulator(
            Tank sourceTank,
            Pump pump,
            Pipeline pipeline,
            Valve valve,
            Valve inletValve)
        {
            this.SourceTank = sourceTank;
            this.Pump = pump;
            this.Pipeline = pipeline;
            this.Valve = valve;
            this.InletValve = inletValve;
        }

        public void SimulateStep(double deltaTimeSeconds)
        {
            double effectiveFlowRate;
            double pressure;
            double resistance;
            double pressureScalingFactor = 0.00002778;

            if (deltaTimeSeconds <= 0)
            {
                throw new ArgumentException("DeltaTimeSeconds must be greater than 0.");
            }

            if (!Pump.IsRunning)
            {
                effectiveFlowRate = 0;
            }
            else if (!Valve.IsOpen)
            {
                effectiveFlowRate = 0;
            }
            else
            {
                effectiveFlowRate = Pump.CurrentFlowRate;
            }

            Pipeline.UpdateFlow(effectiveFlowRate);

            if (effectiveFlowRate > 0)
            {
                double litersPerSecond = effectiveFlowRate / 60.0;
                double transferredLiters = litersPerSecond * deltaTimeSeconds;
                if (transferredLiters > SourceTank.CurrentVolumeLiters)
                {
                    transferredLiters = SourceTank.CurrentVolumeLiters;
                    SourceTank.RemoveWater(transferredLiters);
                }
                else
                {
                    SourceTank.RemoveWater(transferredLiters);
                }
            }

            if (effectiveFlowRate == 0)
            {
                pressure = 0;
            }
            else 
            {
                resistance = Pipeline.LengthMeters / Pipeline.DiameterMeters;
                pressure = effectiveFlowRate * resistance * pressureScalingFactor;
            }      
            Pipeline.UpdatePressure(pressure);

            if (InletValve.IsOpen)
            {
                double incomingLitersPerSecond = InletValve.MaxFlowRate / 60.0;
                double incomingLiters = incomingLitersPerSecond * deltaTimeSeconds;

                SourceTank.AddWater(incomingLiters);
            }
        }
    }
}