using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.environment.events;

namespace SettlersOfValgardGame.settlersOfValgard.events
{
    public class SoVGameEventType : GameEventType
    {
        public SoVGameEventType(string nameText, VColor nameForeground) : base(nameText, nameForeground)
        {
        }
    }
}