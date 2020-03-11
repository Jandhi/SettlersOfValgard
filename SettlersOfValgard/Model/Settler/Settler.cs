using SettlersOfValgard.Model.Building.Workplace;
using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.Model.Settler
{
    public abstract class Settler : INamed
    {
        public abstract string Name { get; }
        public Family Family { get; set; }
        public Workplace Workplace { set; get; }
    }
}