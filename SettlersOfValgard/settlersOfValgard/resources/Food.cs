using SettlersOfValgardGame.settlersOfValgard.resources.storage;
using SettlersOfValgardGame.ui.console.color;

namespace SettlersOfValgardGame.settlersOfValgard.resources
{
    public class Food : Resource
    {
        public Food(string nameText, VColor nameForeground, int size = 1) : base(nameText, nameForeground, size)
        {
        }
        
        
        public static readonly Food Grain = new Food("Grain", VColor.Wheat);
        
        public static readonly Food Meat = new Food("Meat", VColor.Red);
        public static readonly Food Fish = new Food("Fish", VColor.Ocean);
        
        public static readonly Food Berries = new Food("Berries", VColor.Cherry);
        public static readonly Food Apples = new Food("Apples", VColor.Pear);
        public static readonly Food Citrus = new Food("Citrus", VColor.Lemon);

        public override StorageType StorageType => StorageType.Physical;
    }
}