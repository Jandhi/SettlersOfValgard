using SettlersOfValgard.Game.Buildings.Work;
using SettlersOfValgard.Interface.Console;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Game.Settlers
{
    public class Settler : INamed, IColored
    {
        
        
        public Settler(string name, Family family)
        {
            Name = name;
            Family = family;
            family.Members.Add(this);
        }

        public string Name { get; }
        public VColor Color { get; } = VColor.Cyan; //PLACEHOLDER
        public Family Family { get; }
        public Workplace Workplace { set; get; }

        public override string ToString()
        {
            return $"{Color}{Name}{VColor.White}";
        }
    }
}