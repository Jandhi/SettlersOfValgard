using System.Collections.Generic;
using SettlersOfValgard.Model.Settler;

namespace SettlersOfValgard.Model.Building.Residence
{
    public abstract class Residence : Building
    {
        public List<Family> ResidentFamilies { get; set; } = new List<Family>();
        public abstract int MaxFamilies { get; }

        public bool IsFull => ResidentFamilies.Count >= MaxFamilies;

        public void AddResident(Family resident)
        {
            if (IsFull) return; // Cannot add resident if full
            ResidentFamilies.Add(resident);
            resident.Home = this;
        }
    }
}