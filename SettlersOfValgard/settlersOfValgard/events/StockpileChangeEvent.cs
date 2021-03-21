using SettlersOfValgardGame.settlersOfValgard.resources.storage;
using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.environment;
using SettlersOfValgardGame.ui.environment.events;

namespace SettlersOfValgardGame.settlersOfValgard.events
{
    public class StockpileChangeEvent : SoVGameEvent
    {
        public static readonly GameEventType StockPileChangeEventType = new GameEventType("StockpileChangeEvent", VColor.Green);
        
        public StockpileChangeEvent(GameEventType type, SettlersOfValgard game, Ledger transaction) : base("Stockpile changed", transaction, type, game)
        {
            Transaction = transaction;
        }
        
        public Ledger Transaction { get; }
    }
}