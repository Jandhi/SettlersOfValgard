using System;
using System.Collections.Generic;
using Transaction = SettlersOfValgard.resource.Transaction;

namespace SettlersOfValgard.events
{
    public static class StockPileEvents
    {
        public static void DailyStockPileTally(List<Transaction> dailyTransactions)
        {
            String content = "";
            for(var i = 0; i < dailyTransactions.Count; i++)
            {
                if (dailyTransactions[i].Amount > 0)
                {
                    content += "+" + dailyTransactions[i].Amount + " " + dailyTransactions[i].Type;
                }
                else if (dailyTransactions[i].Amount < 0)
                {
                    content += dailyTransactions[i].Amount + " " + dailyTransactions[i].Type;
                }

                if (i < dailyTransactions.Count - 1) content += "\n";
            }
            EventManager.AddEvent(new Event(content, EventType.DailyStockPileTally));
        }
    }
}