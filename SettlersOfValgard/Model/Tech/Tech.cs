using System.Collections.Generic;
using SettlersOfValgard.Model.Building;
using SettlersOfValgard.Model.Name;
using SettlersOfValgard.Model.Rank;

namespace SettlersOfValgard.Model.Tech
{
    public class Tech : INamed, IDescribed
    {
        public Tech(string name, string description, List<Tech> techRequirements, string color, List<Blueprint> blueprints = null, PlayerRank rankRequirement = null)
        {
            Name = name;
            Description = description;
            TechRequirements = techRequirements;
            Color = color;
            RankRequirement = rankRequirement;
            Blueprints = blueprints ?? new List<Blueprint>();
        }

        public string Name { get; }
        public string Description { get; }
        public string Color { get; }
        public List<Tech> TechRequirements { get; } 
        public PlayerRank RankRequirement { get; }
        public List<Blueprint> Blueprints { get; }

        public bool IsAvailable(Settlement.Settlement settlement)
        {
            return (RankRequirement == null || settlement.Rank >= RankRequirement) 
                   && (TechRequirements == null || TechRequirements.TrueForAll(tech => settlement.TechManager.Discovered.Contains(tech)));
        }
    }
}