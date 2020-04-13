using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Message
{
    public class MessageManager
    {
        public List<Message> TodaysMessages { get; set; } = new List<Message>();
        public List<List<Message>> MessageHistory { get; }  = new List<List<Message>>();
        public MessageFilter Filter { get; } = new Model.Message.MessageFilter();

        public void GoThroughMessages(Settlement.Settlement settlement)
        {
            foreach (var msg in TodaysMessages.Where(ev => Filter.OutputMessage(ev)))
            {
                msg.Display();
            }
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