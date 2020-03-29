using SettlersOfValgard.Model.Time;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Resource.Food
{
    public class Food : Resource
    {
        public static readonly Food Grain = new Food("Grain", 0, CustomConsole.Yellow, "");
        public static readonly Food Meat = new Food("Meat", 1, CustomConsole.Red, "Meat");
        public static readonly Food Pom = new Food("Pom", 2, CustomConsole.Red, "");

        protected Food(string name, int value, string color, string description) : base(name, value, color, description)
        {
        }

        public override ResourceType type => ResourceType.Food;
    }
}