using SettlersOfValgard.Model.Name;
using SettlersOfValgard.Model.Resource;

namespace SettlersOfValgard.Model.Building
{
    public class Blueprint : INamed, IDescribed
    {
        public string Name { get; }
        public Building Building { get; }
        public Bundle Cost { get; }

        public Blueprint(string name, Building building, Bundle cost)
        {
            Building = building;
            Cost = cost;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}: {Cost}";
        }

        public string Description => Building.Description;
    }
}