using SettlersOfValgard.Game.Regions;
using SettlersOfValgard.Interface;
using SettlersOfValgard.Interface.Console;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Game.Buildings
{
    public abstract class Building : INamed, IColored, IDescribed
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract VColor Color { get; }
        public Region Region { get; }
        
        //Creates a copy of this building
        public abstract Building Build(Region region);

        protected Building(Region region)
        {
            Region = region;
        }
        
        public override string ToString()
        {
            return Color + Name + VColor.White;
        }
    }
}