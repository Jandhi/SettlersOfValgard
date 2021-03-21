using SettlersOfValgardGame.settlersOfValgard.buildings;
using SettlersOfValgardGame.settlersOfValgard.work;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.settlersOfValgard.settlers
{
    public class Settler : NamedObject, IHasId
    {
        public static int SettlerCount = 0;
        public Settler(string nameText)
        {
            NameText = nameText;
            Id = SettlerCount;
            SettlerCount++;
        }

        public override string NameText { get; }
        public Family Family { get; set; }
        public Residence Residence => Family.Residence;
        public IOccupation Occupation { get; set; }
        public int Id { get; }
    }
}