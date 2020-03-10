using SettlersOfValgard.Old.settler;
using SettlersOfValgard.settler;

namespace SettlersOfValgard.building
{
    public abstract class WorkBuilding : Building
    {
        public abstract int MaxOccupants { get; }
        public abstract void HostWorker(Settler worker);
    }
}