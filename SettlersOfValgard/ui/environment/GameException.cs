using System;
using SettlersOfValgardGame.ui.console.text;
using static SettlersOfValgardGame.ui.console.VConsole;

namespace SettlersOfValgardGame.ui.environment
{
    public class GameException : Exception 
    {
        public GameException(string explanation, Action<Game> callback = null)
        {
            Callback = callback;
            Explanation = Text(explanation);
        }
        public GameException(VText explanation, Action<Game> callback = null)
        {
            Callback = callback;
            Explanation = explanation;
        }
        
        public VText Explanation { get; }
        public Action<Game> Callback { get; }
    }
}