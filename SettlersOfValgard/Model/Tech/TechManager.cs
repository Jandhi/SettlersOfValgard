using System.Collections.Generic;
using System.Linq;

namespace SettlersOfValgard.Model.Tech
{
    public class TechManager
    {
        public TechManager(TechTree tree)
        {
            Tree = tree;
            Discovered = new List<Tech>(tree.StartTechnologies);
        }

        public List<Tech> Discovered { get; }
        public TechTree Tree { get; }

        public List<Tech> GetAvailableTech(Settlement.Settlement settlement)
        {
            return Tree.Technologies.Where(tech => !Discovered.Contains(tech) && tech.IsAvailable(settlement)).ToList();
        }
        public void Discover(Tech tech, Settlement.Settlement settlement)
        {
            //Add all blueprints
            tech.Blueprints.ForEach(blueprint => settlement.Blueprints.Add(blueprint));
            Discovered.Add(tech);
        }
    }
}