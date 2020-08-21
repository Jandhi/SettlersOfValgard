namespace SettlersOfValgard.Game.Info.Messages
{
    /*
     * Basic class to get one-way information to the player
     */
    public abstract class Message
    {

        public abstract string Content { get; }
        public abstract MessagePriority Priority { get; }
        public override string ToString()
        {
            return Content;
        }
    }
}