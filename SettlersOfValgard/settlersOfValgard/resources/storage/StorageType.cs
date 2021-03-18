using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.settlersOfValgard.resources.storage
{
    public class StorageType : NamedObject
    {
        public static readonly StorageType Physical = new StorageType("Physical", VColor.Red);
        
        public StorageType(string nameText, VColor nameForeground)
        {
            NameText = nameText;
            NameForeground = nameForeground;
        }
        
        public override string NameText { get; }
        public override VColor NameForeground { get; }
    }
}