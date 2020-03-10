using SettlersOfValgard.Model.Building.Workplace;

namespace SettlersOfValgard.Model.Settler
{
    public abstract class Settler : INamed
    {
        public abstract string Name { get; }
        public Family Family { get; set; }
        public Workplace Workplace { set; get; }
    }
}