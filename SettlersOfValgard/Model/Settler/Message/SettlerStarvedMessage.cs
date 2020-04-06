using SettlersOfValgard.Model.Core;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Event
{
    public class SettlerStarvedMessage : IMessage
    {
        public SettlerStarvedMessage(Model.Settler.Settler settler)
        {
            Settler = settler;
        }

        public MessageType Type => MessageType.Settler;
        public MessagePriority Priority => MessagePriority.Uncommon;
        
        public Model.Settler.Settler Settler { get; }
        
        public void Trigger(Settlement settlement)
        {
            CustomConsole.WriteLine($"{CustomConsole.Red}{Settler} starved!{CustomConsole.White}");
        }
    }
}