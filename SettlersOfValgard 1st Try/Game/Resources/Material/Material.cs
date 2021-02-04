using SettlersOfValgard.Interface.Console;

namespace SettlersOfValgard.Game.Resources.Material
{
    public class Material : Resource
    {

        public static readonly Material Wood = new Material("Wood",
            "Hardly lumber, suitable for shelter and warmth alike.", 0, VColor.Green, 1);

        public override ResourceType Type => ResourceType.Material;
        public override int Size { get; }

        public Material(string name, string description, int value, VColor color, int size) : base(name, description, value, color)
        {
            Size = size;
        }

        public override Resource[] Values { get; }
    }
}