using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Building.Event
{
    public class ConstructionMessage : Message.Message
    {
        public ConstructionMessage(Building building)
        {
            Building = building;
        }

        public Building Building { get; }
        
        public override MessageType Type => MessageType.Building;
        public override MessagePriority Priority => MessagePriority.Uncommon;
        public override string Contents => $"Constructed a {Building}";
    }
}