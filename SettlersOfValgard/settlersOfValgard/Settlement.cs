using System.Collections.Generic;
using System.Linq;
using SettlersOfValgardGame.settlersOfValgard.buildings;
using SettlersOfValgardGame.settlersOfValgard.buildings.prototypes;
using SettlersOfValgardGame.settlersOfValgard.regions;
using SettlersOfValgardGame.settlersOfValgard.resources.storage;
using SettlersOfValgardGame.settlersOfValgard.settlers;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.settlersOfValgard
{
    public class Settlement : NamedObject
    {
        public Settlement(string nameText)
        {
            NameText = nameText;
        }

        public override string NameText { get; }
        public List<Building> Buildings { get; }= new List<Building>();
        public List<BuildingPrototype> BuildingPrototypes { get; } = new List<BuildingPrototype>();
        public List<Settler> Settlers { get; }= new List<Settler>();
        public Stockpile Stockpile { get; } = new Stockpile((StorageType.Physical, 100));


        public List<Family> Families
        {
            get
            {
                var families = new List<Family>();
                
                foreach (var settler in Settlers.Where(settler => !families.Contains(settler.Family)))
                {
                    families.Add(settler.Family);
                }

                return families;
            }
        }

        public List<Region> Regions { get; } = new List<Region>();
    }
}