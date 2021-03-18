using System.Collections.Generic;
using SettlersOfValgardGame.settlersOfValgard.buildings;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.settlersOfValgard.settlers
{
    public class Family : NamedObject
    {
        public Family(string nameText, List<Settler> members)
        {
            Members = members;
            NameText = nameText;
            foreach (var member in members)
            {
                member.Family = this;
            }
        }

        public Family(string nameText, params Settler[] members)
        {
            NameText = nameText;
            Members = new List<Settler>(members);
            foreach (var member in members)
            {
                member.Family = this;
            }
        }

        public void Add(Settler member)
        {
            Members.Add(member);
            member.Family = this;
        }

        public List<Settler> Members { get; }
        public override string NameText { get; }
        public Residence Residence { get; set; }
    }
}