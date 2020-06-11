using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;
using SettlersOfValgard.Model.Settler.Health;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Message
{
    public class SettlerDeathMessage : Model.Message.Message
    {
        public SettlerDeathMessage(Settler settler, CauseOfDeath causeOfDeath)
        {
            Settler = settler;
            CauseOfDeath = causeOfDeath;
        }

        public Settler Settler { get; }
        public CauseOfDeath CauseOfDeath { get; }

        public override MessageType Type => MessageType.Settler;
        public override MessagePriority Priority => MessagePriority.Important;
        public override string Contents => $"{Settler}{CustomConsole.Red} died by {CauseOfDeath}!";
    }
}