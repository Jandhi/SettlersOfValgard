using SettlersOfValgard.Model.Core;

namespace SettlersOfValgard.Model.Building.Residence
{
    public class Hut : Residence
    {
        public override string Name => "Hut";
        public override string Description => "Modest housing. A roof and four walls.";

        public override int Insulation(Settlement settlement)
        {
            return 1;
        }

        public override Building Construct()
        {
            return new Hut();
        }

        public override int MaxFamilies { get; } = 1;
    }
}