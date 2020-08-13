using SettlersOfValgard.Interface.Console;

namespace SettlersOfValgard.Game.Resources.Material
{
    public class Material : Resource
    {

        public static readonly Material Wood = new Material("Wood",
            "Hardly lumber, suitable for shelter and warmth alike.", 0, VColor.Green);

        public override ResourceType Type => ResourceType.Material;

        public Material(string name, string description, int value, VColor color) : base(name, description, value, color)
        {
        }

        public override Resource[] Values { get; }
    }
}