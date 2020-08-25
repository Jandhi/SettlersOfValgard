using System.Linq;
using SettlersOfValgard.Game.Info.Messages;
using SettlersOfValgard.Game.Resources;
using SettlersOfValgard.Game.Resources.Assets;
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
            MessageManager.DisplayTodaysMessages();
            DoArchiving();
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
            MessageManager.ArchiveMessages();
            Settlement.Stockpile.ArchiveTransactions();
        }
    }
}