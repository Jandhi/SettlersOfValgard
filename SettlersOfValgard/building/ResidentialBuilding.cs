namespace SettlersOfValgard.building
{
    public class ResidentialBuilding : Building
    {
        public readonly int MaxOccupants;

        public ResidentialBuilding(string name, int maxOccupants) : base(name)
        {
            MaxOccupants = maxOccupants;
        }
    }
}