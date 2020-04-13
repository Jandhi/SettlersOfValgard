using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;

namespace SettlersOfValgard.Model.Resource.Transactions
{
    public class NoTransactionsMessage : Message.Message
    {
        public override MessageType Type => MessageType.Stockpile;
        public override MessagePriority Priority => MessagePriority.Essential;
        public override string Contents => "No Resource Transactions Today";
    }
}