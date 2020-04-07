using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Core;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Message
{
    public class MessageManager
    {
        public List<Messages.Message> TodaysMessages { get; set; } = new List<Messages.Message>();
        public List<List<Messages.Message>> MessageHistory { get; }  = new List<List<Messages.Message>>();
        public MessageFilter Filter { get; } = new Model.Message.MessageFilter();

        public void GoThroughMessages(Settlement settlement)
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
            TodaysMessages = new List<Messages.Message>();
        }
    }
}