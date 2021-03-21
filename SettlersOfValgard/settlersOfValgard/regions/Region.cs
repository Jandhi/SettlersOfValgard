using System.Collections.Generic;
using SettlersOfValgardGame.settlersOfValgard.terrain;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.settlersOfValgard.regions
{
    public class Region : NamedObject, IDescribed
    {
        public Region(string nameText, VText description, List<Terrain> terrains, List<Region> neighbours = null)
        {
            NameText = nameText;
            Description = description;
            Terrains = terrains;
            Neighbours = neighbours ?? new List<Region>();
        }

        public override string NameText { get; }
        public VText Description { get; }
        public List<Terrain> Terrains { get; }
        public List<Region> Neighbours { get; }
    }
}