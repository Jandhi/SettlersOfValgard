using System;
using System.Collections.Generic;
using System.Text;
using SettlersOfValgard.Game.Info.Messages;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Game.Resources.Storage
{
    public class TransactionMessage : Message
    {
        public TransactionMessage(Transaction transaction)
        {
            Transaction = transaction;
        }

        public Transaction Transaction { get; }

        public override string Content
        {
            get
            {
                var list = new List<string>();
                foreach (var (resource, amount) in Transaction)
                {
                    list.Add($"{(amount >= 0 ? "+" : "-")}{Math.Abs(amount)} {resource}");
                }

                return list.InsertCommas();
            }
        }

        public override MessagePriority Priority => MessagePriority.Important;
    }
}