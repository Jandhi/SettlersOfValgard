namespace SettlersOfValgard.Model.Message
{
    public interface IMessageFilter
    {
        bool OutputMessage(Message message);
    }
}