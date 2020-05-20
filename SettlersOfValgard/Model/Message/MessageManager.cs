using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Settler.Message;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Message
{
    public class MessageManager
    {
        public List<Message> TodaysMessages { get; set; } = new List<Message>();
        public List<List<Message>> MessageHistory { get; }  = new List<List<Message>>();
        public List<IMessageFilter> Filters { get; } = new List<IMessageFilter>
        {
            new CumulativeFilter<SettlerStarvedMessage>(true),
            new CumulativeFilter<SettlerAteMessage>(true),
            new CumulativeFilter<SettlerUnemployedMessage>(true)
        };

        public void GoThroughMessages(Settlement.Settlement settlement)
        {
            foreach (var msg in TodaysMessages.Where(msg => Filter(msg)))
            {
                msg.Display();
            }
        }

        public bool Filter(Message msg)
        {
            return Filters.TrueForAll(filter => filter.OutputMessage(msg));
        }

        public void ArchiveTodaysMessages()
        {
            MessageHistory.Add(TodaysMessages);
        }

        public void ClearTodaysMessages()
        {
            TodaysMessages = new List<Message>();
        }
    }
}