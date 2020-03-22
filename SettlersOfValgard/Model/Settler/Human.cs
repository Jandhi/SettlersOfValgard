using SettlersOfValgard.Model.Resource;
using SettlersOfValgard.Model.Settler.Event;
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
            var food = settlement.Stockpile.GetHighestOfType(ResourceType.Food);
            if (food == null)
            {
                settlement.AddEvent(new SettlerStarvedEvent(this));
            }
            else
            {
                var meal = new Bundle(food, 1);
                settlement.Stockpile.Remove(meal);
                settlement.AddEvent(new SettlerAteEvent(this, meal));
            }
        }
    }
}