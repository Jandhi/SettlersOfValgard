using System.Collections.Generic;
using SettlersOfValgard.Model.Building;
using SettlersOfValgard.Model.Settler;

namespace SettlersOfValgard.Model
{
    public class Settlement : INamed
    {
        public string Name { get; }

        public List<Settler.Settler> Settlers { get; }
        public List<Family> Families { get; }
        
        public List<Tech.Tech> UnlockedTech { get; }
        public List<Blueprint> Blueprints { get; }

        public Settlement(string name)
        {
            Name = name;
        }
    }
}