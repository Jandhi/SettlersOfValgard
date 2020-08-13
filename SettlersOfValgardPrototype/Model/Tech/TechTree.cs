using System.Collections.Generic;

namespace SettlersOfValgard.Model.Tech
{
    public class TechTree
    {
        public TechTree(List<Tech> startTechnologies, List<Tech> technologies)
        {
            StartTechnologies = startTechnologies;
            Technologies = technologies;
        }

        public List<Tech> StartTechnologies { get; }
        public List<Tech> Technologies { get; }
    }
}