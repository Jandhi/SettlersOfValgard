
using System.Linq;
using SettlersOfValgard.Game.Resources;
using SettlersOfValgardGame.settlersOfValgard.regions;
using SettlersOfValgardGame.settlersOfValgard.settlers;
using SettlersOfValgardGame.settlersOfValgard.terrain;
using SettlersOfValgardGame.ui.console;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.util.random;

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
        
        public void Work(SettlersOfValgard game, Settler settler)
        {
            var table = Terrain.GatherTable;

            if (table == null || table.Count == 0)
            {
                //empty table
                VConsole.WriteWarning(settler + VConsole.Text(" is working on a barren ") + Terrain + VConsole.Text(" terrain!"));
                return;
            }
            
            var total = table.Aggregate(0, (prev, next) => next.Item2 + prev);
            var random = Noise.GetRecursiveNoise(game.Seed, game.Settlement.Day, settler.Id) % total;
            
        }
    }
}