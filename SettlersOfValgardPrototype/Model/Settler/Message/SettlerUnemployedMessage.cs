using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Message
{
    public class SettlerUnemployedMessage : Model.Message.Message
    {
        public override MessageType Type => MessageType.Settler;
        public override MessagePriority Priority => MessagePriority.Essential;
        public override string Contents => $"{Settler}{CustomConsole.Red} is unemployed!";
        public Settler Settler;

        public SettlerUnemployedMessage(Settler settler)
        {
            Settler = settler;
        }
    }
}