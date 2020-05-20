using System.Collections.Generic;
using SettlersOfValgard.Model.Building;
using SettlersOfValgard.Model.Tech;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Varsk.Tech
{
    public class VarskTechTree : TechTree
    {
        
        public static readonly Model.Tech.Tech Survival = new Model.Tech.Tech("Survival", "", 
            null, 
            CustomConsole.Green,
            35,
            new List<Blueprint> {VarskBlueprints.Hut, VarskBlueprints.GatherersHut});

        public static readonly Model.Tech.Tech Forestry = new Model.Tech.Tech("Forestry", "",
            new List<Model.Tech.Tech>{Survival}, 
            CustomConsole.Green,
            35,
            new List<Blueprint> {VarskBlueprints.WoodcuttersHut});
        
        public static readonly Model.Tech.Tech Hunting = new Model.Tech.Tech("Hunting", "", 
            new List<Model.Tech.Tech>{Survival},
            CustomConsole.Green,
            35,
            new List<Blueprint>{VarskBlueprints.HuntersHut});

        public static readonly List<Model.Tech.Tech> VarskStartTechnologies = new List<Model.Tech.Tech>{Survival};
        public static readonly List<Model.Tech.Tech> VarskTechnologies = new List<Model.Tech.Tech>{Survival, Forestry, Hunting};
        
        public VarskTechTree() : base(VarskStartTechnologies, VarskTechnologies)
        {
        }
    }
}