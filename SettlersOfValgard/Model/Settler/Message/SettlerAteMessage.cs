using SettlersOfValgard.Model.Core;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;
using SettlersOfValgard.Model.Resource;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Event
{
    public class SettlerAteMessage : IMessage
    {
        public SettlerAteMessage(Model.Settler.Settler settler, Bundle meal)
        {
            Settler = settler;
            Meal = meal;
        }

        public MessageType Type => MessageType.Settler;
        public MessagePriority Priority => MessagePriority.Negligible;
        
        public Model.Settler.Settler Settler { get; }
        public Bundle Meal { get; }
        
        public void Trigger(Settlement settlement)
        {
            CustomConsole.WriteLine($"{Settler} ate {Meal}");
        }
    }
}