using SettlersOfValgard.Interface.Console;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Game.Resources
{
    public class ResourceType : CustomEnum<ResourceType>
    {
        private ResourceType(string name, string description, int value, VColor color) : base(name, description, value, color)
        {
        }

        public static readonly ResourceType Food = new ResourceType("Food", "Things you can eat.", 0, VColor.Green);
        public static readonly ResourceType Material = new ResourceType("Material", "Things you can make stuff out of.", 1, VColor.Gray);
        public static readonly ResourceType Asset = new ResourceType("Asset", "Intangible things- ideas, faith, debts. The stuff you build a civilization out of.", 2, VColor.Magenta);
        public override ResourceType[] Values => new []{Food, Material};
    }
}