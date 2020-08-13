using System.Collections.Generic;
using SettlersOfValgard.Model.Building.Residence;
using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.Model.Settler
{
    public class Family : INamed
    {
        public Family(string name)
        {
            Name = name + " family";
        }

        public string Name { get; }
        public List<Settler> Members { get; } = new List<Settler>();
        public Residence Home { get; set; }

        public override string ToString()
        {
            return base.ToString();
            //TODO
        }

        public void AddMember(Settler member)
        {
            member.Family = this;
            Members.Add(member);
        }
    }
}