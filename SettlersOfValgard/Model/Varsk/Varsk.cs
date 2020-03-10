using SettlersOfValgard.Model.Settler;

namespace SettlersOfValgard.Model.Varsk
{
    public class Varsk : Human
    {
        public override string Name { get; }

        public Varsk(string name)
        {
            Name = name;
        }
    }
}