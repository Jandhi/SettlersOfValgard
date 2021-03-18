using SettlersOfValgardGame.settlersOfValgard.resources.storage;
using SettlersOfValgardGame.ui.console.color;

namespace SettlersOfValgardGame.settlersOfValgard.resources
{
    public class Material : Resource
    {
        public Material(string nameText, VColor nameForeground, int size) : base(nameText, nameForeground, size)
        {
        }
        
        public static readonly Material Wood = new Material("Wood", VColor.Green, 1);
        public override StorageType StorageType => StorageType.Physical;
    }
}