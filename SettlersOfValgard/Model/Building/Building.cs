using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.Model.Building
{
    public abstract class Building : INamed
    {
        public abstract string Name { get; }

        public abstract Building Construct();
    }
}