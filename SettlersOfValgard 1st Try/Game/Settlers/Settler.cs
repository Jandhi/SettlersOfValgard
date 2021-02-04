using SettlersOfValgard.Game.Buildings.Work;
using SettlersOfValgard.Interface.Console;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Game.Settlers
{
    public class Settler : INamed, IColored
    {
        
        
        public Settler(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public VColor Color { get; } = VColor.Cyan; //PLACEHOLDER
        public Workplace Workplace { set; get; }

        public override string ToString()
        {
            return $"{Color}{Name}{VColor.White}";
        }
    }
}