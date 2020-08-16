using System.Collections.Generic;

namespace SettlersOfValgard.Game.Info.Messages
{
    public class MessageManager
    {
        public List<List<Message>> MessageHistory { get; } = new List<List<Message>>();
        public List<Message> TodaysMessages { get; set; }

        public void Add(Message message)
        {
            TodaysMessages.Add(message);
        }

        public void ArchiveMessages()
        {
            MessageHistory.Add(TodaysMessages);
            TodaysMessages = new List<Message>();
        }
    }
}