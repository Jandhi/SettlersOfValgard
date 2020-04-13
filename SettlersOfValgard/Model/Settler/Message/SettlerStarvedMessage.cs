using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Event
{
    public class SettlerStarvedMessage : Message.Message
    {
        public SettlerStarvedMessage(Model.Settler.Settler settler)
        {
            Settler = settler;
        }

        public override MessageType Type => MessageType.Settler;
        public override MessagePriority Priority => MessagePriority.Uncommon;
        
        public Model.Settler.Settler Settler { get; }
        public override string Contents => $"{CustomConsole.Red}{Settler} starved!{CustomConsole.White}";
    }
}