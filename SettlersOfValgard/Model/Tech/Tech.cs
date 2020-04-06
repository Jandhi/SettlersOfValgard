using System.Collections.Generic;
using SettlersOfValgard.Model.Building;
using SettlersOfValgard.Model.Core;
using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.Model.Tech
{
    public class Tech : INamed, IDescribed
    {
        public Tech(string name, string description, List<Blueprint> blueprints = null)
        {
            Name = name;
            Description = description;
            Blueprints = blueprints ?? new List<Blueprint>();
        }

        public string Name { get; }
        public string Description { get; }
        private List<Blueprint> Blueprints { get; }

        public void Discover(Settlement settlement)
        {
            //Add all blueprints
            Blueprints.ForEach(blueprint => settlement.Blueprints.Add(blueprint));
        }
    }
}