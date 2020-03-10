using SettlersOfValgard.Model.Resource;

namespace SettlersOfValgard.Model.Building
{
    public class Blueprint
    {
        public Building Building { get; }
        public Bundle Cost { get; }

        public Blueprint(Building building, Bundle cost)
        {
            Building = building;
            Cost = cost;
        }
    }
}