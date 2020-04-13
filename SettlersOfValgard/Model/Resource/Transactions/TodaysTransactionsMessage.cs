using System;
using System.Text;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Resource.Transactions
{
    public class TodaysTransactionsMessage : Message.Message
    {
        public TodaysTransactionsMessage(Transaction transactionSum, bool detailed)
        {
            TransactionSum = transactionSum;
            Detailed = detailed;
        }

        public Transaction TransactionSum { get; }

        public override MessageType Type => MessageType.Stockpile;
        public override MessagePriority Priority => MessagePriority.Essential;
        public bool Detailed { get; }

        public override string Contents {
            get
            {
                return Detailed ? ContentsDetailed : ContentsBrief;
            }
        }
        
        public string ContentsBrief => $"Today's Transactions: ({TransactionSum})";

        public string ContentsDetailed
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(CustomConsole.Line);
                sb.AppendLine("Today's Transactions:");
                foreach (var (res, amount) in TransactionSum.Contents)
                {
                    sb.AppendLine($"{res}: {(amount < 0 ? "-" : "+")}{Math.Abs(amount)}");
                }

                return sb.ToString();
            }
        }
    }
}