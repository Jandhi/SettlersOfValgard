namespace SettlersOfValgardGame.ui.environment.events
{
    public interface IGameEventListener
    {
        GameEventType ListenEvent { get; }
        void Notify(GameEvent ev);
    }
}