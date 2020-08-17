using SettlersOfValgard.Interface.Console;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Game.Resources
{
    public abstract class Resource : CustomEnum<Resource>
    { 
        public abstract ResourceType Type { get; }
        public abstract int Size { get; }
        protected Resource(string name, string description, int value, VColor color) : base(name, description, value, color)
        {
        }
    }
}