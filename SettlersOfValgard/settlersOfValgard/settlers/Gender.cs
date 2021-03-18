using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.settlersOfValgard.settlers
{
    public class Gender : NamedObject
    {
        public Gender(string nameText, VColor nameForeground)
        {
            NameText = nameText;
            NameForeground = nameForeground;
        }

        public override string NameText { get; }
        public override VColor NameForeground { get; }
    }
}