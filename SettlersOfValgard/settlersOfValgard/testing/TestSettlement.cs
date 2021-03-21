using System.Collections.Generic;
using SettlersOfValgardGame.settlersOfValgard.buildings;
using SettlersOfValgardGame.settlersOfValgard.content.buildings;
using SettlersOfValgardGame.settlersOfValgard.regions;
using SettlersOfValgardGame.settlersOfValgard.settlers;

namespace SettlersOfValgardGame.settlersOfValgard.testing
{
    public class TestSettlement : Settlement
    {
        public TestSettlement(World testWorld) : base("Test Settlement", new List<Region>{testWorld.StartingRegion})
        {
            GenerateSettlers();
            for (var i = 0; i < 5; i++)
            {
                Buildings.Add(new Residence(TierOneBuildings.Hut));
            }
        }

        public void GenerateSettlers()
        {
            for (var i = 0; i < 9; i++)
            {
                Settlers.Add(new Settler("settler" + i));
            }

            var families = new[] {new Family("Family0"), new Family("Family1"), new Family("Family2")};
            var family = 0;
            foreach (var settler in Settlers)
            {
                families[family].Add(settler);
                family = (family + 1) % 3;
            }
        }
    }
}