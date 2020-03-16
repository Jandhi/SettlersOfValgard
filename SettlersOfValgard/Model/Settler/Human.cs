using SettlersOfValgard.Model.Time;

namespace SettlersOfValgard.Model.Settler
{
    public abstract class Human : Settler
    {
        public abstract int AdultYears { get; }
        public abstract int ElderYears { get; }
        public override bool IsUnderage(Settlement settlement)
        {
            return Date.DaysToYears(AgeInDays(settlement)) >= AdultYears;
        }

        public override void GoEat(Settlement settlement)
        {
            //TODO
        }
    }
}