namespace SettlersOfValgard.Game.Info.Messages
{
    /*
     * Basic class to get one-way information to the player
     */
    public class Message
    {
        public Message(string content, MessagePriority priority)
        {
            Content = content;
            Priority = priority;
        }

        public string Content { get; }
        public MessagePriority Priority { get; }
    }
}