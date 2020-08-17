using SettlersOfValgard.Interface.Console;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Game.Resources.Food
{
    public class Food : Resource
    {
        public override ResourceType Type => ResourceType.Food;
        public override int Size { get; }

        public static readonly Resource Meat = new Food("Meat", "Flesh of dead beasts, now sustenance for the living.", 0, VColor.Red, 1);
        public override Resource[] Values => new[] {Meat};


        public Food(string name, string description, int value, VColor color, int size) : base(name, description, value, color)
        {
            Size = size;
        }
    }
}