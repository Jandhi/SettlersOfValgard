using System.Collections.Generic;
using SettlersOfValgard.Model.Settler;

namespace SettlersOfValgard.Model.Building.Residence
{
    public abstract class Residence : Building
    {
        public List<Family> Residents { get; set; } = new List<Family>();
        public abstract int MaxFamilies { get; }

        public bool IsFull => Residents.Count >= MaxFamilies;

        public void AddResident(Family resident)
        {
            if (IsFull) return; // Cannot add resident if full
            Residents.Add(resident);
            resident.Home = this;
        }
    }
}