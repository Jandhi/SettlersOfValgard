using System.Collections.Generic;
using SettlersOfValgardGame.settlersOfValgard.buildings.prototypes;
using SettlersOfValgardGame.settlersOfValgard.settlers;

namespace SettlersOfValgardGame.settlersOfValgard.buildings
{
    public class Residence : Building
    {
        public Residence(ResidencePrototype residencePrototype)
        {
            ResidencePrototype = residencePrototype;
        }

        public ResidencePrototype ResidencePrototype { get; }
        public override BuildingPrototype BuildingPrototype => ResidencePrototype;
        public int MaxFamilies => ResidencePrototype.MaxFamilies;
        public List<Family> Residents { get; } = new List<Family>();
        public bool IsFull => Residents.Count >= MaxFamilies;
    }
}