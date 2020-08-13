using SettlersOfValgard.Model.Settler.Prestige;
using SettlersOfValgard.Model.Settler.Traits;

namespace SettlersOfValgard.Model.Varsk
{
    public class VarskPrestigeSystem : PrestigeSystem
    {
        public override int CalculatePrestige(Settler.Settler settler)
        {
            //TODO
            var sum = 0;

            if (settler.Traits[Trait.Charm] >= TraitLevel.High)
            {
                sum += 1;
            }  
            else if (settler.Traits[Trait.Charm] <= TraitLevel.Low)
            {
                sum -= 1;
            }
            
            return sum;
        }
    }
}