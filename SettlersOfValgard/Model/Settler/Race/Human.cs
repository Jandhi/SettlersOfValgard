using SettlersOfValgard.Model.Resource;
using SettlersOfValgard.Model.Settler.Event;
using SettlersOfValgard.Model.Settler.Gender;
using SettlersOfValgard.Model.Settler.Health;
using SettlersOfValgard.Model.Settler.Message;
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
        public override int MaxHealth => 10;

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

        public override bool GoEat(Settlement.Settlement settlement)
        {
            var food = settlement.Stockpile.GetHighestOfType(ResourceType.Food);
            if (food == null)
            {
                settlement.AddMessage(new SettlerStarvedMessage(this));
                return false;
            }
            else
            {
                var meal = new Bundle(food, 1);
                settlement.Stockpile.Remove(meal);
                settlement.AddMessage(new SettlerAteMessage(this, meal));
                return true;
            }
        }

        public override void Starve(Settlement.Settlement settlement)
        {
            Harm(1, settlement, CauseOfDeath.Starvation); //Lose health
        }

        public override void Relax(Settlement.Settlement settlement)
        {
            if(HealthLevel > HealthLevel.BadlyWounded)
            {
                Heal(1); // Healing
            }
            else if (HealthLevel == HealthLevel.Dying)
            {
                Harm(1, settlement, CauseOfDeath.Starvation); // Dying
            }
        }

        public BinaryGender Gender { get; }
    }
}