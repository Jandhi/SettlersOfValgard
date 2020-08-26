using System.Linq;
using SettlersOfValgard.Game.Info.Messages;
using SettlersOfValgard.Game.Resources;
using SettlersOfValgard.Game.Resources.Assets;
using SettlersOfValgard.Game.Resources.Storage;
using SettlersOfValgard.Game.Settlers;

namespace SettlersOfValgard.Game
{
    public class Game
    {
        public Game(Settlement settlement)
        {
            Settlement = settlement;
        }

        //Managers
        public MessageManager MessageManager { get; } = new MessageManager();
        
        //Game Classes
        public Settlement Settlement { get; }

        public void PassDay()
        {
            Settlement.Stockpile.ClearLeftovers();
            Work();
            AggregateLabour();
            AddTransactionMessage();
            MessageManager.DisplayTodaysMessages();
            DoArchiving();
        }

        private void AddTransactionMessage()
        {
            var netTransactions =
                Settlement.Stockpile.TodaysTransactions.Aggregate(new Transaction(), (next, total) => next + total).PurgeZeroes();
            if (netTransactions.Count() != 0)
            {
                MessageManager.TodaysMessages.Add(new TransactionMessage(netTransactions));
            }
        }

        private void Work()
        {
            foreach (var settler in Settlement.Settlers)
            {
                settler.Workplace?.HostWork(settler, this);
            }
        }

        private void AggregateLabour()
        {
            var totalLabour = 0;
            foreach (var amount in Settlement.Settlers.Select(CalculateSettlerLabour))
            {
                Settlement.AddResource(Asset.Labour, amount);
                totalLabour += amount;
            }
        }

        private static int CalculateSettlerLabour(Settler settler)
        {
            return settler.Workplace == null ? 2 : 1;
        }

        private void DoArchiving()
        {
            Settlement.Stockpile.ArchiveTransactions();
            MessageManager.ArchiveMessages();
        }
    }
}