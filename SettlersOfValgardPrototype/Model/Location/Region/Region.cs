using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.Model.Location.Region
{
    public class Region : INamed, IDescribed
    {
        public Region(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }
    }
}