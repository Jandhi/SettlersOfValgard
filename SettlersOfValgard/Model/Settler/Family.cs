using System.Collections.Generic;
using SettlersOfValgard.Model.Building.Residence;

namespace SettlersOfValgard.Model.Settler
{
    public class Family
    {
        public List<Model.Settler.Settler> Members { get; } = new List<Model.Settler.Settler>();
        public Residence Home { get; set; }

        public override string ToString()
        {
            return base.ToString();
            //TODO
        }
    }
}