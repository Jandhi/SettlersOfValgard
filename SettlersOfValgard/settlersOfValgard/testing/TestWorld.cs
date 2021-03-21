using System.Collections.Generic;
using SettlersOfValgardGame.settlersOfValgard.regions;
using SettlersOfValgardGame.settlersOfValgard.terrain;
using SettlersOfValgardGame.ui.console;

namespace SettlersOfValgardGame.settlersOfValgard.testing
{
    public class TestWorld : World
    {
        public static readonly Region StartRegion = new Region("test", VConsole.Text(""), new List<Terrain>
        {
            Terrain.Forest,
            Terrain.Forest,
            Terrain.Meadow,
            Terrain.Lake,
            Terrain.River
        });
        
        public TestWorld() : base(StartRegion)
        {
            
        }
    }
}