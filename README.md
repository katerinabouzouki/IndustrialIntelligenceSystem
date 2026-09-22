# Industrial Intelligence System

A C# simulation of an industrial water network designed to model basic process control, monitoring, alarms, equipment protection, and fault scenarios.

## Current Features

- Water tank level simulation
- Pump operation and flow control
- Inlet and outlet valve control
- Pipeline flow and pressure simulation
- Level, flow, and pressure sensors
- Low-level and high-pressure alarms
- Automatic tank level control using thresholds
- Pump protection logic
- Valve fault simulation and automatic recovery
- Time-based fault scenarios

## System Overview

```text
Water Supply
    ↓
Inlet Valve
    ↓
Tank
    ↓
Pump
    ↓
Outlet Valve
    ↓
Pipeline
    ↓
Network
```

The system continuously monitors process values and uses controllers to maintain safe operation. Fault scenarios can be introduced to test alarm and protection behavior.

## Project Structure

- `Models` – Tank, Pump, Valve, Pipeline
- `Sensors` – Level, Flow, and Pressure sensors
- `Alarms` – Process alarm logic
- `Control` – Automatic control and protection logic
- `Simulation` – Water network and fault simulation

## Development Status

This project is currently under development.

Planned improvements include additional equipment faults, reusable interfaces, event/alarm logging, historical process data, and more advanced SCADA-style monitoring.
