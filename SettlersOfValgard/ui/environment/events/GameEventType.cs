using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.ui.environment.events
{
    public class GameEventType : NamedObject
    {
        
        public static GameEventType ErrorEvent = new GameEventType("error", ColorStandards.Error);
        
        public GameEventType(string nameText, VColor nameForeground)
        {
            NameText = nameText;
            NameForeground = nameForeground;
        }

        public override string NameText { get; }
        public override VColor NameForeground { get; }
    }
}