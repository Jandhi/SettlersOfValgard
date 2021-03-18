
using SettlersOfValgardGame.settlersOfValgard.regions;
using SettlersOfValgardGame.ui.console;
using SettlersOfValgardGame.ui.console.text;

namespace SettlersOfValgardGame.settlersOfValgard.work
{
    public class GatherOccupation : IOccupation
    {
        public GatherOccupation(Terrain terrain)
        {
            Terrain = terrain;
        }
        public Terrain Terrain { get; }
        public VText Description => VConsole.Text("Gathering in ") + Terrain;
        
        public void Work(SettlersOfValgard game)
        {
            throw new System.NotImplementedException();
        }
    }
}