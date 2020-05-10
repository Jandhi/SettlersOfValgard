using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Building.Workplace;
using SettlersOfValgard.Model.Name;
using SettlersOfValgard.Model.Settler;
using SettlersOfValgard.Model.Settler.Skill;
using SettlersOfValgard.Model.Settler.Traits;
using SettlersOfValgard.Model.Time;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler
{
    public abstract class Settler : INamed, IDated
    {
        public abstract string Name { get; }
        public Family Family { get; set; } // Home is determined by family
        public abstract Date Birthday { get; }
        public Workplace Workplace { get; set; }
        public Dictionary<Model.Settler.Skill.Skill, int> Experience { get; } = new Dictionary<Model.Settler.Skill.Skill, int>();
        public DefaultValueDictionary<Trait, TraitLevel> Traits = new DefaultValueDictionary<Trait, TraitLevel>(TraitLevel.Average);

        public List<Relationship.Relationship> Relationships { get; } = new List<Relationship.Relationship>();

        public abstract bool CanWork(Settlement.Settlement settlement);

        public int AgeInDays(Settlement.Settlement settlement)
        {
            return settlement.TodaysDate.DaysSinceSettlement - Birthday.DaysSinceSettlement;
        }
        public abstract bool IsUnderage(Settlement.Settlement settlement);

        public override string ToString()
        {
            return $"{CustomConsole.Green}{Name}{CustomConsole.White}";
        }

        public SkillLevel SkillLevel(Model.Settler.Skill.Skill skill)
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

        public void GainXp(Settlement.Settlement settlement, Model.Settler.Skill.Skill skill, int amount)
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
                settlement.MessageManager.TodaysMessages.Add(new SkillIncreasedMessage(this, skill, SkillLevel(skill)));
            }
        }

        public abstract void GoEat(Settlement.Settlement settlement);

        public string MajorTraits()
        {
            var strings = new List<string>();
            foreach (var (trait, level) in Traits.Dictionary)
            {
                if (level >= TraitLevel.High)
                {
                    strings.Add(trait.PositiveDescriptor);
                } 
                else if (level <= TraitLevel.Low)
                {
                    strings.Add(trait.NegativeDescriptor);
                }
            }

            return StringsUtil.CommaList(strings.ToArray());
        }
    }
}