using SettlersOfValgard.Model.Time;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Resource.Food
{
    public class Food : Resource
    {
        public static readonly Food Grain = new Food("Grain", 0, CustomConsole.Yellow, "");
        public static readonly Food Meat = new Food("Meat", 1, CustomConsole.Red, "Meat");
        public static readonly Food Fruit = new Food("Fruit", 2, CustomConsole.Blue, "");
        public static readonly Food Pom = new Food("Pom", 2, CustomConsole.Red, "");
        public static readonly Food WildGreens = new Food("Wild Greens", 3, CustomConsole.Green, "");
        public static readonly Food[] Foods = {Grain, Meat, Fruit, Pom, WildGreens};
        public override Resource[] Values => Foods;

        protected Food(string name, int value, string color, string description) : base(name, value, color, description)
        {
        }

        public override ResourceType type => ResourceType.Food;
    }
}