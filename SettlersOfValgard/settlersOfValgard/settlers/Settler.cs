using SettlersOfValgardGame.settlersOfValgard.buildings;
using SettlersOfValgardGame.settlersOfValgard.work;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.settlersOfValgard.settlers
{
    public class Settler : NamedObject
    {
        public Settler(string nameText)
        {
            NameText = nameText;
        }

        public override string NameText { get; }
        public Family Family { get; set; }
        public Residence Residence => Family.Residence;
        public IOccupation Occupation { get; set; }
    }
}