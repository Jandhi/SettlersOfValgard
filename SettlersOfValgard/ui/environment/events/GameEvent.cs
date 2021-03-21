using SettlersOfValgardGame.ui.console;
using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.ui.environment.events
{
    public class GameEvent : NamedObject, IDescribed
    {
        
        public GameEvent(string nameText, VText description, GameEventType type, Game game, VColor nameForeground = null)
        {
            NameText = nameText;
            Description = description;
            Type = type;
            Game = game;
            NameForeground = nameForeground;
        }

        public override string NameText { get; }
        public override VColor NameForeground { get; }
        public VText Description { get; }
        public Game Game { get; }
        public GameEventType Type { get; }
    }
}