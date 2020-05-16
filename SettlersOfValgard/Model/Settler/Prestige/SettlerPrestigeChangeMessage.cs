using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Prestige
{
    public class SettlerPrestigeChangeMessage : Model.Message.Message
    {
        public SettlerPrestigeChangeMessage(Settler settler, PrestigeLevel oldLevel)
        {
            Settler = settler;
            OldLevel = oldLevel;
        }

        public override MessageType Type => MessageType.Settler;
        public override MessagePriority Priority => MessagePriority.Negligible;

        public override string Contents
        {
            get
            {
                var gained = OldLevel < Settler.PrestigeLevel;
                var verb = gained? $"{CustomConsole.Green}gained{CustomConsole.White}" : $"{CustomConsole.Red}lost{CustomConsole.White}";
                return $"{Settler} has {verb} prestige, from {OldLevel} to {Settler.PrestigeLevel}!";
            }
        }

        public Settler Settler { get; }
        public PrestigeLevel OldLevel { get; }
    }
}