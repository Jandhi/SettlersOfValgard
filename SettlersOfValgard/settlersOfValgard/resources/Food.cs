using SettlersOfValgardGame.settlersOfValgard.resources.storage;
using SettlersOfValgardGame.ui.console.color;

namespace SettlersOfValgardGame.settlersOfValgard.resources
{
    public class Food : Resource
    {
        public Food(string nameText, VColor nameForeground, int size) : base(nameText, nameForeground, size)
        {
        }

        public override StorageType StorageType => StorageType.Physical;
    }
}