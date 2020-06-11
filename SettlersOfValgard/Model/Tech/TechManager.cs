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
        public Tech CurrentResearch { get; set; }

        public List<Tech> GetAvailableTech(Settlement.Settlement settlement)
        {
            return Tree.Technologies.Where(tech => !Discovered.Contains(tech) && tech.IsAvailable(settlement)).ToList();
        }

        public void MakeProgress(Settlement.Settlement settlement)
        {
            if (CurrentResearch != null)
            {
                CurrentResearch.Progress += settlement.ResearchRate;
                if (CurrentResearch.Progress >= CurrentResearch.Cost)
                {
                    Discover(CurrentResearch, settlement);
                    CurrentResearch = null;
                }
            }
        }
        
        public void Discover(Tech tech, Settlement.Settlement settlement)
        {
            settlement.AddMessage(new TechDiscoveredMessage(tech));
            //Add all blueprints
            tech.Blueprints.ForEach(blueprint => settlement.Blueprints.Add(blueprint));
            Discovered.Add(tech);
        }
    }
}