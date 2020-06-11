using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Building.Workplace;
using SettlersOfValgard.Model.Name;
using SettlersOfValgard.Model.Settler;
using SettlersOfValgard.Model.Settler.Health;
using SettlersOfValgard.Model.Settler.Message;
using SettlersOfValgard.Model.Settler.Prestige;
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

        public abstract int MaxHealth { get; }
        public int Health { get; set; }
        public virtual bool Diseased { get; } = false;

        public HealthLevel HealthLevel => HealthLevel.Get(Health / (double) MaxHealth, Diseased);
        public Dictionary<Model.Settler.Skill.Skill, int> Experience { get; } = new Dictionary<Model.Settler.Skill.Skill, int>();
        public DefaultValueDictionary<Trait, TraitLevel> Traits = new DefaultValueDictionary<Trait, TraitLevel>(TraitLevel.Average);

        protected Settler() {}

        public void Setup()
        {
            Health = MaxHealth;
        }

        public List<Relationship.Relationship> Relationships { get; } = new List<Relationship.Relationship>();

        public PrestigeLevel PrestigeLevel => PrestigeLevel.PrestigeToLevel(PrestigeAmount);
        public int PrestigeAmount { get; set; }

        public abstract bool CanWork(Settlement.Settlement settlement);

        public int AgeInDays(Settlement.Settlement settlement)
        {
            return settlement.TodaysDate.DaysSinceSettlement - Birthday.DaysSinceSettlement;
        }
        public abstract bool IsUnderage(Settlement.Settlement settlement);

        public override string ToString()
        {
            return $"{PrestigeLevel.Color}{Name}{CustomConsole.White}";
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

        public virtual void DoWork(Settlement.Settlement settlement)
        {
            //Can't work
            if (Workplace == null) return;
            
            var discipline = Traits[Trait.Discipline];
            if (discipline == TraitLevel.BelowAverage && RandomUtil.Chance(1, 40) || 
                discipline == TraitLevel.Low && RandomUtil.Chance(1, 20) ||
                discipline == TraitLevel.VeryLow && RandomUtil.Chance(1, 10))
            {
                //skipped work
                settlement.AddMessage(new SettlerSkippedWorkMessage(this));
            }
            else
            {
                Workplace.HostWork(this, settlement);
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

        //Lazy evaluation of prestige: it is only recalculated after important changes
        public void UpdatePrestige(Settlement.Settlement settlement)
        {
            var oldLevel = PrestigeLevel;
            PrestigeAmount = settlement.Culture.PrestigeSystem.CalculatePrestige(this);
            if (oldLevel != PrestigeLevel)
            {
                settlement.AddMessage(new SettlerPrestigeChangeMessage(this, oldLevel));
            }
        }
    }
}