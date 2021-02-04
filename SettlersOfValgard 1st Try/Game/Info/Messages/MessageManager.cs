using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Interface.Console;

namespace SettlersOfValgard.Game.Info.Messages
{
    public class MessageManager
    {
        public List<List<Message>> MessageHistory { get; } = new List<List<Message>>();
        public List<Message> TodaysMessages { get; set; } = new List<Message>();

        public List<Message> FilteredMessages
        {
            get { return TodaysMessages.Where(msg => msg.Priority >= MinimumPriority).ToList(); }
        }
        public MessagePriority MinimumPriority { get; set; } = MessagePriority.Common;

        public void Add(Message message)
        {
            TodaysMessages.Add(message);
        }
        
        public void DisplayTodaysMessages()
        {
            TodaysMessages.ForEach(msg => VConsole.WriteLine($"{msg}"));
        }

        public void ArchiveMessages()
        {
            MessageHistory.Add(TodaysMessages);
            TodaysMessages = new List<Message>();
        }
    }
}