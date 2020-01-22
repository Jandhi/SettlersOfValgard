using SettlersOfValgard.settler;

namespace SettlersOfValgard.building
{
    public abstract class WorkBuilding : Building
    {
        public readonly int MaxOccupants;
        
        public WorkBuilding(string name, int maxOccupants) : base(name)
        {
            MaxOccupants = maxOccupants;
        }

        public abstract void HostWorker(Settler worker);
    }
}