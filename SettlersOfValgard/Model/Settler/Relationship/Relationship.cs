using System.Collections.Generic;

namespace SettlersOfValgard.Model.Settler.Relationship
{
    public abstract class Relationship
    {
        public abstract List<Settler> Members { get; }
    }
}