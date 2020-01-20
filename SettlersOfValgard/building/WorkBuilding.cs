namespace SettlersOfValgard.building
{
    public class WorkBuilding : Building
    {
        public readonly int MaxOccupants;
        
        public WorkBuilding(string name, int maxOccupants) : base(name)
        {
            MaxOccupants = maxOccupants;
        }
    }
}