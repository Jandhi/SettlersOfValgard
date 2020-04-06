using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Core;
using SettlersOfValgard.Model.Event;

namespace SettlersOfValgard.Model.Message
{
    public class MessageManager
    {
        public List<IMessage> TodaysEvents { get; set; } = new List<IMessage>();
        public List<List<IMessage>> MessageHistory { get; }  = new List<List<IMessage>>();
        public Model.Message.Message Filter { get; } = new Model.Message.Message();

        public void GoThroughEvents(Settlement settlement)
        {
            foreach (var msg in TodaysEvents.Where(ev => Filter.OutputMessage(ev)))
            {
                msg.Trigger(settlement);
            }
        }

        public void ArchiveTodaysEvents()
        {
            MessageHistory.Add(TodaysEvents);
        }

        public void ClearTodaysEvents()
        {
            TodaysEvents = new List<IMessage>();
        }
    }
}