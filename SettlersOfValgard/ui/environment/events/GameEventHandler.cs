using System.Collections.Generic;
using SettlersOfValgardGame.ui.console;

namespace SettlersOfValgardGame.ui.environment.events
{
    public class GameEventHandler
    {
        public Dictionary<GameEventType, List<IGameEventListener>> Listeners = new Dictionary<GameEventType, List<IGameEventListener>>();

        public void AddListener(IGameEventListener listener)
        {
            if (Listeners.ContainsKey(listener.ListenEvent))
            {
                Listeners[listener.ListenEvent].Add(listener);
            }
            else
            {
                Listeners.Add(listener.ListenEvent, new List<IGameEventListener>{listener});
            }
        }

        public void AcceptEvent(GameEvent ev)
        {
            VConsole.WriteDebug(ev);
            if (Listeners.ContainsKey(ev.Type))
            {
                Listeners[ev.Type].ForEach(listener => listener.Notify(ev));
            }
        }
    }
}