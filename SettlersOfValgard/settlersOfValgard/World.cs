using SettlersOfValgardGame.settlersOfValgard.regions;

namespace SettlersOfValgardGame.settlersOfValgard
{
    public class World
    {
        public World(Region startingRegion)
        {
            StartingRegion = startingRegion;
        }

        public Region StartingRegion { get; }
    }
}