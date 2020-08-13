using System.Linq;
using SettlersOfValgard.Model.Settler.Skill;

namespace SettlersOfValgard.Model.Building.Workplace
{
    public abstract class SkilledWorkplace : Workplace
    {
        /*
         * A workplace that requires or uses a certain skill
         */
        public abstract Skill Skill { get; }

        public override Settler.Settler GetWorkerToReplace()
        {
            if (Workers.Count == 0) return null; // No Worker to Replace
            
            var replace = Workers[0];
            foreach (var worker in Workers.Where(worker => worker.SkillLevel(Skill) < replace.SkillLevel(Skill)))
            {
                replace = worker;
            }
            return replace;
        }
    }
}