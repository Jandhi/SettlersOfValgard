﻿using System.Text;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Resource.Transactions;
using SettlersOfValgard.Model.Settler.Event;
using SettlersOfValgard.Model.Settler.Message;

namespace SettlersOfValgard.Model.Message
{
    public class MessageFilter
    {
        private bool AccumulateSettlerAteMessages { get; } = true;
        private bool AccumulateSettlerStarvedMessages { get; } = false;
        private bool DetailedTransactions { get; } = false;
        public MessagePriority OutputThreshold { get; } = MessagePriority.Negligible;
        
        public bool OutputMessage(Message ev)
        {
            return ev switch
            {
                SettlerAteMessage _ => !AccumulateSettlerAteMessages,
                CumulativeSettlerAteMessage _ => AccumulateSettlerAteMessages,
                SettlerStarvedMessage _ => !AccumulateSettlerStarvedMessages,
                CumulativeSettlerStarvedMessage _ => AccumulateSettlerStarvedMessages,
                TodaysTransactionsMessage transactionsMessage => (transactionsMessage.Detailed == DetailedTransactions),
                _ => (ev.Priority >= OutputThreshold)
            };
        }
    }
}