using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Resource
{
    public class ResourceType : CustomEnum
    {
        public static readonly ResourceType Material =
            new ResourceType("Material", 0, CustomConsole.Green);

        public static readonly ResourceType Refined =
            new ResourceType("Refined", 1, CustomConsole.Red);

        public static readonly ResourceType Food =
            new ResourceType("Food", 2, CustomConsole.Yellow);

        public static readonly ResourceType Luxury =
            new ResourceType("Luxury", 3, CustomConsole.Magenta);

        public static readonly ResourceType[] Types = {Material, Refined, Food, Luxury};

        private ResourceType(string name, int value, string color) : base(name, value, color)
        {
        }
    }
}