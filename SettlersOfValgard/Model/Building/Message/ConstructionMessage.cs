using SettlersOfValgard.Model.Core;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Building.Event
{
    public class ConstructionMessage : IMessage
    {
        public ConstructionMessage(Building building)
        {
            Building = building;
        }

        public Building Building { get; }
        
        public MessageType Type => MessageType.Building;
        public MessagePriority Priority => MessagePriority.Uncommon;
        public void Trigger(Settlement settlement)
        {
            CustomConsole.WriteLine($"Constructed a {Building}");
        }
    }
}