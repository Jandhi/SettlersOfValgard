using System.Collections.Generic;

namespace SettlersOfValgard.Model.Settler.Relationship
{
    public abstract class Relationship
    {
        public List<Settler> Members { get; set; }
    }
}