using System.Collections.Generic;

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
        
        public void Discover(Tech tech, Settlement.Settlement settlement)
        {
            //Add all blueprints
            tech.Blueprints.ForEach(blueprint => settlement.Blueprints.Add(blueprint));
            Discovered.Add(tech);
        }
    }
}