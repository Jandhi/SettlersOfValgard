using SettlersOfValgardGame.settlersOfValgard.buildings;
using SettlersOfValgardGame.settlersOfValgard.settlers;
using SettlersOfValgardGame.ui.console;
using SettlersOfValgardGame.ui.console.text;

namespace SettlersOfValgardGame.settlersOfValgard.work
{
    public class WorkplaceOccupation : IOccupation
    {
        public WorkplaceOccupation(Workplace workplace)
        {
            Workplace = workplace;
        }

        public Workplace Workplace { get; }
        public VText Description => VConsole.Text("Works at ") + Workplace;

        public void Work(SettlersOfValgard game, Settler settler)
        {
            Workplace.WorkplacePrototype.HostWorker(game, settler);
        }
    }
}