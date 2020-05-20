using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;

namespace SettlersOfValgard.Model.Settler.Message
{
    public class SettlerSkippedWorkMessage : Model.Message.Message
    {
        public override MessageType Type => MessageType.Settler;
        public override MessagePriority Priority => MessagePriority.Common;
        public Settler Settler;

        public SettlerSkippedWorkMessage(Settler settler)
        {
            Settler = settler;
        }

        public override string Contents => $"{Settler} has skipped work at the {Settler.Workplace}!";
    }
}