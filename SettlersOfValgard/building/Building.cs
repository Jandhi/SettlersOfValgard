using SettlersOfValgard.resource;
using SettlersOfValgard.time;

namespace SettlersOfValgard.building
{
    public abstract class Building : INamed, IAgeable
    {
        protected Building() {}

        public int Count { get; set; } = 0;

        public Age Age { get; } = new Age();
        public abstract string Name { get; }

        public abstract ResourceBundle Cost { get; }
        public abstract int WorkDays { get; }
        public abstract Building BuildNew();
    }
}