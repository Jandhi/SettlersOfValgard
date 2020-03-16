using SettlersOfValgard.Model.Time;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Resource.Material
{
    public class Material : Resource
    {
        public static readonly Material Wood = new Material("Wood", 0, CustomConsole.Green, "Hardy lumber, for building.");
        public static readonly Material Stone = new Material("Stone", 1, CustomConsole.Gray, "");

        protected Material(string name, int value, string color, string description) : base(name, value, color, description)
        {
        }
    }
}