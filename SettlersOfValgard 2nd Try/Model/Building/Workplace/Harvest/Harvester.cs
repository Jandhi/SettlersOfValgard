using System;
using System.Collections.Generic;
using SettlersOfValgard.Model.Resource;
using SettlersOfValgard.Model.Settler.Skill;

namespace SettlersOfValgard.Model.Building.Workplace.Harvest
{
    public abstract class Harvester : SkilledWorkplace
    {
        public abstract Dictionary<Resource.Resource, double> BaseRates { get; }

        public virtual double BuildingEfficiency(Settlement.Settlement settlement, Resource.Resource resource,
            Settler.Settler worker)
        {
            return 1.0;
        }

        public double WorkerEfficiency(Settler.Settler worker)
        {
            var level = worker.SkillLevel(Skill);
            if (level == SkillLevel.Unskilled)
            {
                return 0.7;
            }

            if (level == SkillLevel.Novice)
            {
                return 0.85;
            }

            if (level == SkillLevel.Apprentice)
            {
                return 1;
            }

            if (level == SkillLevel.Journeyman)
            {
                return 1.15;
            }

            if (level == SkillLevel.Expert)
            {
                return 1.3;
            }

            if (level == SkillLevel.Master)
            {
                return 1.5;
            }

            return 1;
        }

        public override void HostWork(Settler.Settler worker, Settlement.Settlement settlement)
        {
            var harvest = new Bundle();
            foreach (var (resource, rate) in BaseRates)
            {
                var amount = GetHarvest(settlement, resource, rate, worker);
            
                if (amount > 0)
                {
                    harvest.Contents.Add(resource, amount);
                }
            }
            
            //TODO Transactions
            settlement.Stockpile.Add(harvest);
            worker.GainXp(settlement, Skill, 1);
        }

        private int GetHarvest(Settlement.Settlement settlement, Resource.Resource resource, double rate, Settler.Settler worker)
        {
            var efficiency = BuildingEfficiency(settlement, resource, worker) * WorkerEfficiency(worker);
            var guaranteedHarvest = (int) (rate * efficiency);
            var uncertainHarvest = guaranteedHarvest - rate * efficiency;
            return guaranteedHarvest + (new Random().NextDouble() < uncertainHarvest ? 1 : 0);
        }
    }
}