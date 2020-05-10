using SettlersOfValgard.Model.Resource;
using SettlersOfValgard.Model.Settler.Event;
using SettlersOfValgard.Model.Settler.Gender;
using SettlersOfValgard.Model.Settler.Traits;
using SettlersOfValgard.Model.Time;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler
{
    public abstract class Human : Inheritor, IGendered<BinaryGender>
    {
        protected Human(BinaryGender gender)
        {
            Gender = gender;
        }

        public abstract int AdultYears { get; }
        public abstract int ElderYears { get; }

        /*
         * Humans can work if they are not underage
         */
        public override bool CanWork(Settlement.Settlement settlement)
        {
            return !IsUnderage(settlement);
        }

        public override bool IsUnderage(Settlement.Settlement settlement)
        {
            return Date.DaysToYears(AgeInDays(settlement)) <= AdultYears;
        }

        public override void GoEat(Settlement.Settlement settlement)
        {
            var food = settlement.Stockpile.GetHighestOfType(ResourceType.Food);
            if (food == null)
            {
                settlement.AddMessage(new SettlerStarvedMessage(this));
            }
            else
            {
                var meal = new Bundle(food, 1);
                settlement.Stockpile.Remove(meal);
                settlement.AddMessage(new SettlerAteMessage(this, meal));
            }
        }

        public BinaryGender Gender { get; }
    }
}