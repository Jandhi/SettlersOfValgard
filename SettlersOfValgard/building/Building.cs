using SettlersOfValgard.time;

namespace SettlersOfValgard.building
{
    public abstract class Building : INamed, IAgeable
    {
        public string Name { get; }

        protected Building(string name)
        {
            Name = name;
        }

        public Age Age { get; } = new Age();
    }
}