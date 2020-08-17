using SettlersOfValgard.Game.Assets;
using SettlersOfValgard.Game.Info.Messages;

namespace SettlersOfValgard.Game
{
    public class Game
    {
        //Managers
        public MessageManager MessageManager { get; }
        
        //Game Classes
        public Settlement Settlement { get; }

        public void PassDay()
        {
            Work();
            Labour();
        }

        public void Work()
        {
            foreach (var settler in Settlement.Settlers)
            {
                settler.Workplace?.HostWork(settler);
            }
        }

        public void Labour()
        {
            foreach (var settler in Settlement.Settlers)
            {
                if (settler.Workplace == null)
                {
                    Settlement.AddAsset(Asset.Labour, 2);
                }
                else
                {
                    Settlement.AddAsset(Asset.Labour, 1);
                }
            }
        }
    }
}