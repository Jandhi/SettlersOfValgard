using SettlersOfValgard.resource;

namespace SettlersOfValgard.building.Residential
{
    public class Tent : ResidentialBuilding
    {
        public override string Name => "Tent";
        public override int MaxOccupants => 3;
        public override ResourceBundle Cost => new ResourceBundle().Modify(Resource.Wood, 3);
        public override int WorkDays => 1;
        
        public override Building BuildNew()
        {
            return new Tent();
        }
    }
}