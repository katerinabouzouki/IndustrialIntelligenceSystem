using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialIntelligenceSystem.Models
{
    class Tank
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public double CapacityLiters { get; private set; }
        public double CurrentVolumeLiters { get; private set; }
        public double LevelPercent
        {
            get { return (CurrentVolumeLiters / CapacityLiters) * 100; }
        }

        public Tank(int id, string name, double capacityLiters, double currentVolumeLiters)
        {
            this.Id = id;
            this.Name = name;

            if (capacityLiters <= 0)
            {
                throw new ArgumentException("Capacity must be greater than zero.");
            }

            this.CapacityLiters = capacityLiters;


            if (currentVolumeLiters < 0 || currentVolumeLiters > capacityLiters)
            {
                throw new ArgumentException("Curent volume must be greater than or equal to zero and less than or equal to capacity.");
            }

            this.CurrentVolumeLiters = currentVolumeLiters;
        }

        public void AddWater(double liters)
        {
            if (liters <= 0 || CurrentVolumeLiters + liters > CapacityLiters)
            {
                Console.WriteLine("The value of liters is not valid!");
            }
            else
            {
                CurrentVolumeLiters += liters;
            }
        }

        public void RemoveWater(double liters)
        {
            if (liters <= 0 || CurrentVolumeLiters - liters < 0)
            {
                Console.WriteLine("The value of liters is not valid!");
            }
            else
            {
                CurrentVolumeLiters -= liters;
            }
        }
    }
}
