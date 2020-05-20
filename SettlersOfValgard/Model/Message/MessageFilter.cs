using System.Collections.Generic;
using SettlersOfValgard.Model.Event;

namespace SettlersOfValgard.Model.Message
{
    public interface IMessageFilter
    {
        bool OutputMessage(Message message);
    }
}