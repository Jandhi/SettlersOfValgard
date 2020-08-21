using System;
using SettlersOfValgard.Interface.Console;

namespace SettlersOfValgard.Game.Resources.Assets
{
    public class Asset : Resource
    {
        public Func<Settlement, int> Limit { get; }
        
        public Asset(string name, string description, int value, VColor color, Func<Settlement, int> limit) : base(name, description, value, color)
        {
            Limit = limit;
        }
        
        public static readonly Asset Labour = new Asset("Labour", "Hours of sweat and blood.", 0, VColor.Red, LabourLimit);

        public override Resource[] Values => new Resource[] {Labour};

        public static int LabourLimit(Settlement settlement)
        {
            return settlement.Settlers.Count * 5;
        }

        public override ResourceType Type => ResourceType.Asset;
        public override int Size => 0;
    }
}