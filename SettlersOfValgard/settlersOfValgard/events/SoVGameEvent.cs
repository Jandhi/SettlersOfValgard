using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.environment;
using SettlersOfValgardGame.ui.environment.events;

namespace SettlersOfValgardGame.settlersOfValgard.events
{
    public class SoVGameEvent : GameEvent
    {
        public SoVGameEvent(string nameText, VText description, GameEventType type, SettlersOfValgard game, VColor nameForeground = null) : base(nameText, description, type, game, nameForeground)
        {
            Game = game;
        }

        public new SettlersOfValgard Game { get; }
    }
}