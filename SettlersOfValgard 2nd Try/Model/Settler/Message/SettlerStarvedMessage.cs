using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Message
{
    public class SettlerStarvedMessage : Model.Message.Message
    {
        public SettlerStarvedMessage(Model.Settler.Settler settler)
        {
            Settler = settler;
        }

        public override MessageType Type => MessageType.Settler;
        public override MessagePriority Priority => MessagePriority.Uncommon;
        
        public Settler Settler { get; }
        public override string Contents => $"{Settler} {CustomConsole.Red}starved!{CustomConsole.White}";
    }
}