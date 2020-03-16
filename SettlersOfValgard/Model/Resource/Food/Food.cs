using SettlersOfValgard.Model.Time;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Resource.Food
{
    public class Food : Resource
    {
        public static readonly Food Meat = new Food("Meat", 1, CustomConsole.Red, "Meat");
        
        protected Food(string name, int value, string color, string description) : base(name, value, color, description)
        {
        }
    }
}