using SettlersOfValgardGame.settlersOfValgard.resources.storage;
using SettlersOfValgardGame.ui.console.color;

namespace SettlersOfValgardGame.settlersOfValgard.resources
{
    public class Material : Resource
    {
        public Material(string nameText, VColor nameForeground, int size = 1) : base(nameText, nameForeground, size)
        {
        }
        
        public static readonly Material Wood = new Material("Wood", VColor.Wood);
        public static readonly Material Stone = new Material("Stone", VColor.Stone);
        public static readonly Material Herbs = new Material("Herbs", VColor.Leaf);
        
        public override StorageType StorageType => StorageType.Physical;
    }
}