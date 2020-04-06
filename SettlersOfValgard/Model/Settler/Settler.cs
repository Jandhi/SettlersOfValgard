using System.Collections.Generic;
using SettlersOfValgard.Model.Building.Workplace;
using SettlersOfValgard.Model.Core;
using SettlersOfValgard.Model.Name;
using SettlersOfValgard.Model.Settler.Skill;
using SettlersOfValgard.Model.Time;

namespace SettlersOfValgard.Model.Settler
{
    public abstract class Settler : INamed, IDated
    {
        public abstract string Name { get; }
        public Family Family { get; set; }
        public abstract Date Birthday { get; }
        public Workplace Workplace { get; set; }
        public abstract bool CanWork(Settlement settlement);
        public Dictionary<Skill.Skill, int> Experience { get; } = new Dictionary<Skill.Skill, int>();

        public int AgeInDays(Settlement settlement)
        {
            return settlement.TodaysDate.DaysSinceSettlement - Birthday.DaysSinceSettlement;
        }
        public abstract bool IsUnderage(Settlement settlement);

        public override string ToString()
        {
            return Name;
        }

        public SkillLevel SkillLevel(Skill.Skill skill)
        {
            if (Experience.ContainsKey(skill))
            {
                return Skill.SkillLevel.XPtoLevel(Experience[skill]);
            }
            else
            {
                return Skill.SkillLevel.Unskilled;
            }
        }

        public void GainXp(Settlement settlement, Skill.Skill skill, int amount)
        {
            var before = SkillLevel(skill);
            if (Experience.ContainsKey(skill))
            {
                Experience[skill] += amount;
            }
            else
            {
                Experience.Add(skill, amount);
            }
            if (before < SkillLevel(skill))
            {
                //Level Up!
                //TODO
            }
        }

        public abstract void GoEat(Settlement settlement);
    }
}