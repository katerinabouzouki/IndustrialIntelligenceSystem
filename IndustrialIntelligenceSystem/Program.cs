using IndustrialIntelligenceSystem.Alarms;
using IndustrialIntelligenceSystem.Control;
using IndustrialIntelligenceSystem.Models;
using IndustrialIntelligenceSystem.Sensors;
using IndustrialIntelligenceSystem.Simulation;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialIntelligenceSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Tank tank1 = new Tank(1, "T-101", 10000, 6500);
            Pump pump1 = new Pump(1, "P-101", 500);
            Valve valve1 = new Valve(1, "V-101", 200);
            Valve valve2 = new Valve(2, "V-102", 500);
            Pipeline pipeline1 = new Pipeline(1, "PL-101", 120, 0.25);

            LevelSensor levelSensor1 = new LevelSensor("LT-101", "Tank Level", tank1);
            FlowSensor flowSensor1 = new FlowSensor("FT-101", "Pump Flow", pump1);
            PressureSensor pressureSensor1 = new PressureSensor("PT-101", "Pipeline Pressure", pipeline1);
            LowLevelAlarm lowLevelAlarm1 = new LowLevelAlarm("Low Tank Level", "Tank T-101 level is below 20%", AlarmSeverity.Critical, levelSensor1, 20);
            HighPressureAlarm highPressureAlarm1 = new HighPressureAlarm("High Pipeline Pressure", "Pipeline PL-101 pressure is over 4.5 bar", AlarmSeverity.Critical, pressureSensor1, 4.5);
            PumpProtectionController pumpProtectionController1 = new PumpProtectionController(lowLevelAlarm1, pump1);
            TankLevelController tankLevelController1 = new TankLevelController(levelSensor1, valve2, 30, 80);
            FaultScenario faultScenario1 = new FaultScenario(valve2, 500, 2050);

            pump1.Start();
            pump1.SetFlowRate(300);
            valve1.Open();

            WaterNetworkSimulator simulator = new WaterNetworkSimulator(tank1, pump1, pipeline1, valve1, valve2);

            for (int i = 10; i < 4000 + 1; i += 10)
            {
                levelSensor1.ReadValue();
                flowSensor1.ReadValue();
                pressureSensor1.ReadValue();

                lowLevelAlarm1.Evaluate();
                pumpProtectionController1.Evaluate();
                highPressureAlarm1.Evaluate();
                tankLevelController1.Evaluate();
                faultScenario1.Evaluate(i);

                simulator.SimulateStep(10);

                levelSensor1.ReadValue();
                flowSensor1.ReadValue();
                pressureSensor1.ReadValue();

                Console.WriteLine($"Time: {i}s");
                Console.WriteLine($"Tank level: {levelSensor1.CurrentValue} {levelSensor1.Unit}");
                Console.WriteLine($"Flow: {flowSensor1.CurrentValue} {flowSensor1.Unit}");
                Console.WriteLine($"Pressure: {pressureSensor1.CurrentValue} {pressureSensor1.Unit}");
                Console.WriteLine($"Pump running: {pump1.IsRunning}");
                Console.WriteLine($"Inlet valve open: {valve2.IsOpen}");
                Console.WriteLine($"Inlet valve faulted: {valve2.IsFaulted}");
                Console.WriteLine();
            }
        }
    }
}
