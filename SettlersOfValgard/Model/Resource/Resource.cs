using SettlersOfValgard.Model.Name;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Resource
{
    public abstract class Resource : CustomEnum<Resource>, IDescribed
    {
        public abstract ResourceType type { get; }
        
        protected Resource(string name, int value, string color, string description) : base(name, value, color)
        {
            Description = description;
        }

        public string Description { get; }
    }
}