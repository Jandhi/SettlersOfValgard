namespace SettlersOfValgard.Model.Message
{
    public class CumulativeFilter<T> : IMessageFilter where T : Message
    {
        public CumulativeFilter(bool active)
        {
            Active = active;
        }
        public bool Active { get; set; }
            
        public bool OutputMessage(Message message)
        {
            return Active ? !(message is T) : !(message is CumulativeMessage<T>);
        }
    }
}