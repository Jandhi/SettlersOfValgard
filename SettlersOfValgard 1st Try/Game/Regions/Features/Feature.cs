using SettlersOfValgard.Interface.Console;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Game.Regions.Features
{
    public class Feature : CustomEnum<Feature>
    {
        public Feature(string name, string description, int value, VColor color) : base(name, description, value, color)
        {
        }

        public static readonly Feature Plain = new Feature("Plain", "", 0, VColor.Yellow);
        public static readonly Feature Forest = new Feature("Forest", "", 1, VColor.Green);
        public static readonly Feature Mountain = new Feature("Mountain", "", 2, VColor.Gray);
        public static readonly Feature River = new Feature("River", "", 5, VColor.Cyan);
        public static readonly Feature Lake = new Feature("Lake", "", 6, VColor.Blue);

        public override Feature[] Values { get; } = {Plain, Forest, Mountain, River, Lake};
    }
}