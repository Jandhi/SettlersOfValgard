using SettlersOfValgard.Model.Time;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Resource.Material
{
    public class Material : Resource
    {
        public static readonly Material Wood = new Material("Wood", 0, CustomConsole.Green, "Hardy lumber, for building.");
        public static readonly Material Stone = new Material("Stone", 1, CustomConsole.Gray, "");
        public static readonly Material[] Materials = {Wood, Stone};

        protected Material(string name, int value, string color, string description) : base(name, value, color, description)
        {
            
        }

        public override ResourceType type => ResourceType.Material;
        public override Resource[] Values => Materials;
    }
}