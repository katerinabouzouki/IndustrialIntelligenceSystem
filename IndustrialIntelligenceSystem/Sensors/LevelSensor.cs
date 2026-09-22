using System;
using System.Collections.Generic;
using System.Text;
using IndustrialIntelligenceSystem.Models;

namespace IndustrialIntelligenceSystem.Sensors
{
    class LevelSensor : Sensor
    {
        public Tank Tank { get; private set; }

        public LevelSensor(string id, string name, Tank tank) : base(id , name, "%")
        {
            this.Tank = tank;
        }

        public void ReadValue()
        {
            CurrentValue = Tank.LevelPercent;
        }
    }
}
