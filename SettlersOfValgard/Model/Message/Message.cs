using SettlersOfValgard.Model.Event;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Message
{
    public abstract class Message
    {
        
        public abstract MessageType Type { get; }
        public abstract MessagePriority Priority { get; }
        public abstract string Contents { get; }

        public virtual void Display()
        {
            CustomConsole.WriteLine(Contents);
        }
    }
}