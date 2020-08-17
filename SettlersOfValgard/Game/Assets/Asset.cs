using System;
using SettlersOfValgard.Interface.Console;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Game.Assets
{
    public class Asset : CustomEnum<Asset>
    {
        public Func<Settlement, int> Limit { get; }
        
        public Asset(string name, string description, int value, VColor color, Func<Settlement, int> limit) : base(name, description, value, color)
        {
            Limit = limit;
        }
        
        public static readonly Asset Labour = new Asset("Labour", "Hours of sweat and blood.", 0, VColor.Red, LabourLimit);

        public override Asset[] Values => new[] {Labour};

        public static int LabourLimit(Settlement settlement)
        {
            return settlement.Settlers.Count * 5;
        }
    }
}