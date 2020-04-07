using SettlersOfValgard.Model.Core;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;
using SettlersOfValgard.Model.Resource;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Event
{
    public class SettlerAteMessage : Messages.Message
    {
        public SettlerAteMessage(Model.Settler.Settler settler, Bundle meal)
        {
            Settler = settler;
            Meal = meal;
        }

        public override MessageType Type => MessageType.Settler;
        public override MessagePriority Priority => MessagePriority.Negligible;
        
        public Model.Settler.Settler Settler { get; }
        public Bundle Meal { get; }

        public override string Contents => $"{Settler} ate {Meal}";
    }
}