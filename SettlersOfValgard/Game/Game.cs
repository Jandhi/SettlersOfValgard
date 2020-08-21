using SettlersOfValgard.Game.Info.Messages;
using SettlersOfValgard.Game.Resources.Assets;

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
            Work();
            Labour();
            MessageManager.DisplayTodaysMessages();
        }

        public void Work()
        {
            foreach (var settler in Settlement.Settlers)
            {
                settler.Workplace?.HostWork(settler, this);
            }
        }

        public void Labour()
        {
            var totalLabour = 0;
            foreach (var settler in Settlement.Settlers)
            {
                int amount;
                if (settler.Workplace == null)
                {
                    amount = 2;
                    
                }
                else
                {
                    amount = 1;
                }
                Settlement.AddResource(Asset.Labour, amount);
                totalLabour += amount;
            }
            MessageManager.Add(new AssetGainMessage(totalLabour, Asset.Labour));
        }
    }
}