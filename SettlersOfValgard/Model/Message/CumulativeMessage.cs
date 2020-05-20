using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Event;

namespace SettlersOfValgard.Model.Message
{
    public abstract class CumulativeMessage<T> : Message where T : Message
    {
        public int Count;

        public CumulativeMessage(List<Message> todaysMessages)
        {
            ProcessMessages(todaysMessages);
        }

        public void ProcessMessages(List<Message> todaysMessages)
        {
            foreach (var tMessage in todaysMessages.OfType<T>())
            {
                ProcessMessage(tMessage);
            }
        }

        public virtual void ProcessMessage(T tMessage)
        {
            Count++;
        } 
    }
}